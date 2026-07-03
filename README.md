
This project demonstrates how to build an academic management system using **ASP.NET Core Web API** with **PostgreSQL** as the database backend. It showcases how to design, manage, and implement relational database concepts using **Entity Framework Core (EF Core)**.

## Key Features & Concepts
* **Database Integration:** Implements ORM functionality using `Npgsql.EntityFrameworkCore.PostgreSQL`.
* **Entity Relationships:** Models real-world data structures and relationships between **Students**, **Courses**, and **Enrollments**.
* **Data Persistence Strategies:** Demonstrates both **Soft Delete** functionality (via an `isPassedOut` flag in the Student entity) and traditional **Hard Delete** execution.

---

## Tech Stack & Packages
* **Framework:** ASP.NET Core Web API
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core
* **Nuget Packages:**
  * `Microsoft.EntityFrameworkCore.Design`
  * `Npgsql.EntityFrameworkCore.PostgreSQL`

## API Endpoints refrence

### Students Route
| HTTP Method | Endpoint | Description | Payload (JSON) / Notes |
| :--- | :--- | :--- | :--- |
| `POST` | `/students` | Create a new student | `{ "name": "string", "email": "string" }` |
| `GET` | `/students` | Get all active students | |
| `GET` | `/students/{id}` | Get a specific student by ID | |
| `PUT` | `/students/{id}` | Update a student's information | `{ "name": "string", "email": "string" }` |
| `DELETE` | `/students/{id}/soft-delete` | Soft delete a student | Sets the `isPassedOut` flag to `true` |
| `GET` | `/students/passed-out` | Fetch all soft-deleted students | Retrieves records where `isPassedOut == true` |

### Courses Route
| HTTP Method | Endpoint | Description | Payload (JSON) |
| :--- | :--- | :--- | :--- |
| `POST` | `/courses` | Create a new course | `{ "name": "string", "description": "string", "creditHours": 0 }` |
| `GET` | `/courses` | Get all available courses | |
| `GET` | `/courses/{id}` | Get a specific course by ID | |
| `PUT` | `/courses/{id}` | Update course details | `{ "name": "string", "description": "string", "creditHours": 0 }` |

### Enrollments Route (Join Table)
| HTTP Method | Endpoint | Description | Payload (JSON) / Notes |
| :--- | :--- | :--- | :--- |
| `POST` | `/enrollments` | Enroll a student in a course | `{ "studentId": 0, "courseId": 0 }` |
| `GET` | `/enrollments` | Get all active enrollments | Handles relationships between entities |
| `GET` | `/enrollments/{id}` | Get specific enrollment details | |
| `DELETE` | `/enrollments/{id}` | Hard delete an enrollment | Permanently removes the enrollment record |

---


## Database setup guide
After creating model and adding model in DbContext run this command to create database
Follow these commands in your package manager console or terminal to generate your database and apply your relational schemas after creating / modifying your models and updating in `DbContext`.


### 1. Generate a Migration
Create a snapshot of your current entity models:
```bash
dotnet ef migrations add initial_migration_setup

```bash
dotnet ef database update

