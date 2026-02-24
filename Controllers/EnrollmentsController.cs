using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgreSQLConnection.Dtos.EnrollmentDto;
using PostgreSQLConnection.Models;
using PostgreSQLConnection.Services;

namespace PostgreSQLConnection.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly EnrollmentsService _enrollmentsService;

        public EnrollmentsController(EnrollmentsService enrollmentsService)
        {
            _enrollmentsService = enrollmentsService;
        }

        // get all enrollments
        [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            var enrollments = await _enrollmentsService.GetEnrollmentsAsync();
            return Ok(enrollments);
        }

        // get enrollment by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollment(int id)
        {
            var enrollment = await _enrollmentsService.GetEnrollmentAsync(id);
            if (enrollment is null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        // create new enrollment
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(CreateEnrollmentDto enrollmentDto)
        {
            var enrollment = new Enrollment
            {
                StudentId = enrollmentDto.StudentId,
                CourseId = enrollmentDto.CourseId
            };

            await _enrollmentsService.CreateEnrollmentAsync(enrollment);
            return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, enrollment);
        }


        // delete enrollment

    //    var student = await _context.Students
    //.Include(s => s.Enrollments)
    //.ThenInclude(e => e.Course)
    //.FirstOrDefaultAsync(s => s.Id == id);

    //    var courses = student.Enrollments.Select(e => e.Course).ToList();

    }
}
