# ToDoList API

* An app that provides todolist APIs. You can visit below to use postman collection to call apis and see sample of calls.
https://github.com/frkn2076/ToDoListAPI/blob/develop/ToDoListAPI.postman_collection.json

<br>

## Features
* ### Authentication
  | Service                     | Method        | Endpoint                  |
  | --------------------------- |:-------------:| ------------------------- |
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

## Note
 * Set isrefresh parameter of Filter Lists By Pagination as **true** when you change your filter model or when you start pagination again.
 
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


