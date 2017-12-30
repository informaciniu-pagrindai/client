using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public class ShortcutHandler : IDisposable
    {
        private TimeTracker timeTracker;
        private Project activeProject = null;

        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                CreateHandle(new CreateParams());
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    KeyPressed?.Invoke(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;
            
            public void Dispose()
            {
                DestroyHandle();
            }
        }

        private Window _window = new Window();
        private int _currentId;
        private List<KeyPressedEventArgs> _hotkeys = new List<KeyPressedEventArgs>();

        public ShortcutHandler(TimeTracker parent)
        {
            timeTracker = parent;

            // register the event of the inner native window.
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args) {
                KeyPressed?.Invoke(this, args);
            };
            KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

        }
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Console.WriteLine("HOTKEY: "+e.Modifiers.ToString() + " + " + e.Key.ToString());

            int index = _hotkeys.IndexOf(e);
            string actionid = null;
            if (index >= 0)
                actionid = _hotkeys[index].ActionID;
            timeTracker.HandleActionEvent(actionid);
        }

        public void RegisterShortcuts(Project project)
        {
            ClearShortcuts();
            activeProject = project;
            foreach (ProjectAction act in project.Actions)
            {
                if (act.Shortcut != null)
                {
                    // Register hotkey
                    string[] keys = act.Shortcut.Split();
                    if (!RegisterHotKey(ModifierKeys.Control, Keys.F1, act.Id)) // TESTHACK, use parsed values
                        Console.WriteLine("Could not register hotkey: " + act.Shortcut);
                }
            }
        }
        public void ClearShortcuts()
        {
            activeProject = null;
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }
            _hotkeys.Clear();
            _currentId = 0;
        }

        private bool RegisterHotKey(ModifierKeys modifiers, Keys key, string actionID)
        {
            if (!RegisterHotKey(_window.Handle, _currentId+1, (uint)modifiers, (uint)key))
                return false;
            _currentId = _currentId + 1;
            _hotkeys.Add(new KeyPressedEventArgs(modifiers, key) { ActionID = actionID });
            return true;
        }
        
        public event EventHandler<KeyPressedEventArgs> KeyPressed;
        
        public void Dispose()
        {
            // unregister all the registered hot keys.
            ClearShortcuts();

            // dispose the inner native window.
            _window.Dispose();
        }
    }
    
    public class KeyPressedEventArgs : EventArgs, IEquatable<KeyPressedEventArgs>
    {
        public ModifierKeys Modifiers;
        public Keys Key;
        public string ActionID = null;
        public int id = -1;

        internal KeyPressedEventArgs(ModifierKeys modifiers, Keys key)
        {
            Modifiers = modifiers;
            Key = key;
        }

        public bool Equals(KeyPressedEventArgs other)
        {
            return ((Modifiers == other.Modifiers) && (Key == other.Key));
        }
    }
    
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}
