# ToDoList API

* An app that provides todolist APIs.

<br>

## Features
* ### Authentication
  | Service                     | Method        | Endpoint                  | Description                     |
  | --------------------------- |:-------------:| ------------------------- | --------------------------------|
  | Register                    | POST          | authentication/register   |
  | Login                       | POST          | authentication/login      |
* ### Item
  | Service                     | Method        | Endpoint                  |
  | --------------------------- |:-------------:| ------------------------- |
  | Create List                 | POST          | item/list                 |
  | Filter Lists By Pagination  | POST          | item/list/all             |
  | Create Task                 | POST          | item/task                 |
  | Filter Tasks                | POST          | item/task/all             |
  | Create Task                 | POST          | item/task                 |
  | Update List                 | PUT           | item/list/{id}            |
  | Update Task                 | PUT           | item/task/{id}            |
  | Update Task Status          | PUT           | item/task/{id}            |
  | Update User TimeZone        | PUT           | item/user/timezone        |
  | Delete List                 | DELETE        | item/list/{id}            |
  | Delete Task                 | DELETE        | item/task/{id}            |
  


<br>

## Databases
 * PostgreSQL

<br>

## Tools
 * Dapper
 * JWT
 * Swagger
 * Docker
 * Fluent Validation
 * Mapster
