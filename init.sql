CREATE TABLE IF NOT EXISTS profile (
    id serial PRIMARY KEY,
    username VARCHAR (20) UNIQUE NOT NULL,
    password VARCHAR (100) NOT NULL
);

CREATE TABLE IF NOT EXISTS list (
    id serial PRIMARY KEY,
    title VARCHAR (20) NOT NULL,
    description VARCHAR (100) NOT NULL,
    date TIMESTAMP WITH TIME ZONE NOT NULL,
    profileId NUMERIC (7) NOT NULL
);

CREATE TABLE IF NOT EXISTS task (
    id serial PRIMARY KEY,
    title VARCHAR (20) NULL,
    description VARCHAR (100) NULL,
    dateline TIMESTAMP WITH TIME ZONE NULL,
    isDone BOOLEAN NOT NULL,
    listId NUMERIC (7) NOT NULL
);