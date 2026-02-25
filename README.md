
This project demonstrates how to build a CRUD-based academic management system using ASP.NET Core with PostgreSQL as the database. It leverages Entity Framework Core for ORM functionality, along with Microsoft Entity FrameworkCore Design and Npgsql EntityFrameworkCore PostgreSQL packages for database integration. The system models Students, Courses, and Enrollments, showcasing how to design and manage relationships between entities in a real-world academic context implementing concept of soft delete (by adding isPassedOut flag in student record) and hard delete.


# Students route
- /students -> POST request to create a new student, takes JSON { name, email }
- /students -> GET request to get all students
- /students/{id} -> GET request to get a student by id
- /students/{id} -> PUT request to update a student by id, takes JSON { name, email }
- /students/{id}/soft-delete -> DELETE request to set isPassedOut to true for a student by id
- /students/passed-out -> GET request to get all students with isPassedOut set to true

# Course route
- /courses -> POST request to create a new course, takes JSON { name, description,creditHours }
- /courses -> GET request to get all courses
- /courses/{id} -> GET request to get a course by id
- /courses/{id} -> PUT request to update a course by id, takes JSON { name, description, creditHours }

# Enrollment route
- /enrollments -> POST request to create a new enrollment, takes JSON { studentId, courseId }
- /enrollments -> GET request to get all enrollments
- /enrollments/{id} -> GET request to get an enrollment by id
- /enrollments/{id} -> DELETE request to delete an enrollment by id



# Command perform for database

- dotnet ef migrations add message

- dotnet ef database update

