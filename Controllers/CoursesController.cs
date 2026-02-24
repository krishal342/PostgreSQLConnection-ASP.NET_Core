using Microsoft.AspNetCore.Mvc;
using PostgreSQLConnection.Services;
using PostgreSQLConnection.Models;
using PostgreSQLConnection.Dtos.CourseDto;


namespace PostgreSQLConnection.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly CoursesService _coursesService;

        public CoursesController(CoursesService coursesService)
        {
            _coursesService = coursesService;
        }


        //get all courses
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _coursesService.GetCoursesAsync();
            return Ok(courses);
        }

        // get course by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _coursesService.GetCourseAsync(id);
            if (course is null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // create
        [HttpPost]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            await _coursesService.CreateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        // update course
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto courseDto)
        {
            var course = await _coursesService.UpdateCourseAsync(id, courseDto);
            if (course is null)
            {
                return NotFound();
            }
            return Ok(course);

        }
    }
}
