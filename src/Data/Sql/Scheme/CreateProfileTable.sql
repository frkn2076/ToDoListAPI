CREATE TABLE IF NOT EXISTS profile (
    id serial PRIMARY KEY,
    username VARCHAR (20) UNIQUE NULL,
    password VARCHAR (100) NOT NULL,
);