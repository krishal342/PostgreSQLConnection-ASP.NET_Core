using Microsoft.EntityFrameworkCore;
using PostgreSQLConnection.Data;
using PostgreSQLConnection.Dtos.CourseDto;
using PostgreSQLConnection.Dtos.EnrollmentDto;
using PostgreSQLConnection.Dtos.StudentDto;
using PostgreSQLConnection.Models;

namespace PostgreSQLConnection.Services
{
    public class EnrollmentsService
    {
        private readonly AppDbContext _context;

        public EnrollmentsService(AppDbContext context)
        {
            _context = context;
        }

        // create
        public async Task CreateEnrollmentAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        // read all 
        public async Task<List<ResponseEnrollmentDto>> GetEnrollmentsAsync() =>
             await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .Select(e => new ResponseEnrollmentDto
            {
                Id = e.Id,
                StudentId = e.StudentId,
                CourseId = e.CourseId,
                EnrollmentDate = e.EnrollmentDate,
                Student = new StudentDtoForEnrollment
                {
                    Id = e.Student!.Id,
                    Name = e.Student.Name,
                    Email = e.Student.Email
                },
                Course = new CourseDtoForEnrollment 
                {
                    Id = e.Course!.Id,
                    Title = e.Course.Title,
                    Description = e.Course.Description,
                    CreditHours = e.Course.CreditHours
                }
            })
            .ToListAsync();

        // read by id
        public async Task<ResponseEnrollmentDto?> GetEnrollmentAsync(int id) =>
            await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
                        .Select(e => new ResponseEnrollmentDto
                        {
                            Id = e.Id,
                            StudentId = e.StudentId,
                            CourseId = e.CourseId,
                            EnrollmentDate = e.EnrollmentDate,
                            Student = new StudentDtoForEnrollment
                            {
                                Id = e.Student!.Id,
                                Name = e.Student.Name,
                                Email = e.Student.Email
                            },
                            Course = new CourseDtoForEnrollment
                            {
                                Id = e.Course!.Id,
                                Title = e.Course.Title,
                                Description = e.Course.Description,
                                CreditHours = e.Course.CreditHours
                            }
                        })
            .FirstOrDefaultAsync(e => e.Id == id);

        // delete
        public async Task<bool?> DeleteEnrollmentAsync(int id)
            {
                var enrollment = await _context.Enrollments.FindAsync(id);
                if (enrollment is null)
                {
                    return null;
                }
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
                return true;
        }
    }
}
