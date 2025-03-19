drop schema public cascade;
create schema public;

-- Users table 
CREATE TABLE Users (
    Id TEXT PRIMARY KEY,
    Username TEXT UNIQUE NOT NULL,
    Email Text NOT NULL,
    PasswordHash TEXT NOT NULL,
    Salt TEXT NOT NULL
);