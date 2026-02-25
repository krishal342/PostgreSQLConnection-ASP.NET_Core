using Microsoft.EntityFrameworkCore;
using PostgreSQLConnection.Data;
using PostgreSQLConnection.Dtos.CourseDto;
using PostgreSQLConnection.Models;

namespace PostgreSQLConnection.Services
{
    public class CoursesService
    {
        private readonly AppDbContext _context;

        public CoursesService(AppDbContext context)
        {
            _context = context;
        }

        // create
        public async Task CreateCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        // read
        public async Task<List<Course>> GetCoursesAsync() =>
            await _context.Courses
            .Include(c => c.Enrollments)
            .ToListAsync();

        // read by id
        public async Task<Course?> GetCourseAsync(int id) =>
            await _context.Courses
            .Include(c => c.Enrollments)
            .FirstOrDefaultAsync(c => c.Id == id);

        // update
        public async Task<Course?> UpdateCourseAsync(int id , UpdateCourseDto courseDto )
        {
            var course = await _context.Courses.FindAsync(id);
            if( course is null)
            {
                return null;
            }
            course.Title = courseDto.Title ?? course.Title;
            course.Description = courseDto.Description ?? course.Description;
            course.CreditHours = courseDto.CreditHours ?? course.CreditHours;

            await _context.SaveChangesAsync();
            return course;
        }

    }
}
