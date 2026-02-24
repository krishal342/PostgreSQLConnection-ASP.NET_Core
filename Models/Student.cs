namespace PostgreSQLConnection.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime AdmissionOn { get; set;  } = DateTime.UtcNow;
        public bool IsPassedOut { get; set; } = false;

        // navigation property
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
