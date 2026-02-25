using PostgreSQLConnection.Dtos.CourseDto;
using PostgreSQLConnection.Dtos.StudentDto;

namespace PostgreSQLConnection.Dtos.EnrollmentDto
{
    public class ResponseEnrollmentDto
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }
    
            public StudentDtoForEnrollment? Student { get; set; }
    
            public CourseDtoForEnrollment? Course { get; set; }
    }
}
