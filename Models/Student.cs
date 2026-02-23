namespace PostgreSQLConnection.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime AdmissionOn { get; set;  } = DateTime.UtcNow;
        public List<Course> Courses { get; set; } = new ();
        public bool IsPassedOut { get; set; } = false;

    }
}
