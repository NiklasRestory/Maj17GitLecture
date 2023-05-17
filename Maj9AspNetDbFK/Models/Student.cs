using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maj9AspNetDbFK.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(45)]
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        public List<Course> Courses { get; set; }
    }
}
