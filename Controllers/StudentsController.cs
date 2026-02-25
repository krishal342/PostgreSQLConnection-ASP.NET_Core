using Microsoft.AspNetCore.Mvc;
using PostgreSQLConnection.Dtos.StudentDto;
using PostgreSQLConnection.Models;
using PostgreSQLConnection.Services;


namespace PostgreSQLConnection.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService _studentsService;

        public StudentsController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        // get all students
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentsService.ReadStudentsAsync();
            return Ok(students);
        }

        // get student by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentsService.ReadStudentAsync(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("passed-out")]
        public async Task<IActionResult> GetPassedOutStudents()
        {
            var students = await _studentsService.ReadPassedOutStudentsAsync();
            return Ok(students);
        }

        // create new student
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            student.Email = student.Email.ToLower();
            await _studentsService.CreateStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // update student
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto updatedStudent)
        {
            var student = await _studentsService.UpdateStudentAsync(id, updatedStudent);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // delete student
        [HttpDelete("{id}/soft-delete")]
        public async Task<IActionResult> MarkAsPassedOut(int id)
        {
            var result = await _studentsService.MarkAsPassedOutAsync(id);
            if (result is null)
            {
                return NotFound();
            }


            return NoContent();

        }
    }
}