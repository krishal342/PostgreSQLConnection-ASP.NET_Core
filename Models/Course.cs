namespace PostgreSQLConnection.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public int CreditHours { get; set; }

        // navigation property
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
