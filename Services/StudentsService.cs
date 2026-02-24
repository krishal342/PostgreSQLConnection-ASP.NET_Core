using Microsoft.EntityFrameworkCore;
using PostgreSQLConnection.Data;
using PostgreSQLConnection.Dtos.StudentDto;
using PostgreSQLConnection.Models;

namespace PostgreSQLConnection.Services
{
    public class StudentsService
    {
        private readonly AppDbContext _context;

        public StudentsService(AppDbContext context)
        {
            _context = context;
        }

        // create
        public async Task CreateStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

        }

        // read
        public async Task<List<Student>> ReadStudentsAsync() =>
            await _context.Students.ToListAsync();

        // read by id
        public async Task<Student?> ReadStudentAsync(int id) =>
            await _context.Students.FindAsync(id);

        // update
        public async Task<Student?> UpdateStudentAsync(int id, UpdateStudentDto studentDto)
        {
            var student = await _context.Students.FindAsync(id);
            if ( student is null)
            {
                return null;
            }
            
            student.Name = studentDto.Name ?? student.Name;
            student.Email = studentDto.Email?.ToLower() ?? student.Email;

            await _context.SaveChangesAsync();
            return student;

        }

        // delete
        //public async Task DeleteStudentAsync()
        //{

        //}

    }
}
