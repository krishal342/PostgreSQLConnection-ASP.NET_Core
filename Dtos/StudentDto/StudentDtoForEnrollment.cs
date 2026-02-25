namespace PostgreSQLConnection.Dtos.StudentDto
{
    public class StudentDtoForEnrollment
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;


        public bool IsPassedOut { get; set; }
    }
}
