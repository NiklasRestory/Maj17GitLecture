using System.ComponentModel.DataAnnotations;

namespace Maj9AspNetDbFK.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        // To make a many to many relationship, simply make sure both
        // sides have a list of the other. Course has a list of Students,
        // and Student has a list of Courses. When we have it like that,
        // Add-Migration will create a Link/Pivot/Junktion/Join Table on its own.
        public List<Student> Students { get; set; }
    }
}
