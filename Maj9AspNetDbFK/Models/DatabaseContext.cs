using Microsoft.EntityFrameworkCore;

namespace Maj9AspNetDbFK.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SchoolClass> SchoolClass { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
