using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maj9AspNetDbFK.Models
{
    [Table("class")]
    public class SchoolClass
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(45)]
        [Required]
        [Column("class_name")]
        public string Name { get; set; }

        // To make a one-to-many relationship, have a list in the class of
        // the kind of object that should be able to have many of the other.
        // Lots of students in a school class, but students can only be in
        // one class. Migration will automatically create the foreign key
        // in Student table like this.
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
