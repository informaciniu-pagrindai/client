CREATE TABLE UserProjects
(
	projectID varchar (20) NOT NULL,
	title varchar (20) NOT NULL,
	PRIMARY KEY(projectID)
);

CREATE TABLE UserData
(
	userdataID varchar (20) NOT NULL,
	login varchar (20),
	pass varchar (40),
	fk_activeProject varchar (20),
	PRIMARY KEY(userdataID),
	CONSTRAINT fkc_activeProject FOREIGN KEY(fk_activeProject) REFERENCES UserProjects (projectID)
);

CREATE TABLE ActionTypes
(
	actionTypeID varchar (20) NOT NULL,
	fk_project varchar (20) NOT NULL,
	name varchar (20) NOT NULL,
	PRIMARY KEY(actionTypeID),
	CONSTRAINT fkc_project FOREIGN KEY(fk_project) REFERENCES UserProjects (projectID)
);

CREATE TABLE Actions
(
	actionID varchar (20) NOT NULL,
	fk_actionType varchar (20) NOT NULL,
	isLocal boolean NOT NULL,
	startTime integer NOT NULL,
	endTime integer,
	modified boolean NOT NULL,
	PRIMARY KEY(actionID),
	CONSTRAINT fkc_action_actionType FOREIGN KEY(fk_actionType) REFERENCES ActionTypes (actionTypeID)
);

CREATE TABLE Shortcuts
(
	shortcutID varchar (20) NOT NULL,
	fk_actionType varchar (20) NOT NULL,
	isLocal boolean NOT NULL,
	startTime integer NOT NULL,
	endTime integer,
	modified boolean NOT NULL,
	PRIMARY KEY(shortcutID),
	CONSTRAINT fkc_shortcut_actionType FOREIGN KEY(fk_actionType) REFERENCES ActionTypes (actionTypeID)
);
