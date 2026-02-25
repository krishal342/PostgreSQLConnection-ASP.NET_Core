namespace PostgreSQLConnection.Dtos.CourseDto
{
    public class CourseDtoForEnrollment
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
         public int CreditHours { get; set; }
    }
}
