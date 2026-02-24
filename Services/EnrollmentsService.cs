using Microsoft.EntityFrameworkCore;
using PostgreSQLConnection.Data;
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
        public async Task<List<Enrollment>> GetEnrollmentsAsync() =>
            await _context.Enrollments.ToListAsync();

        // read by id
        public async Task<Enrollment?> GetEnrollmentAsync(int id) =>
            await _context.Enrollments.FindAsync(id);

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
