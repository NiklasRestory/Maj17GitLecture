using Maj9AspNetDbFK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maj9AspNetDbFK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        DatabaseContext dbContext;
        public SchoolController(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Route("addStuff")]
        [HttpGet]
        public void AddToDatabase()
        {
            Student student = new Student() { Name = "Jim", Age = 23 };
            Student student2 = new Student() { Name = "Jake", Age = 26 };
            Student student3 = new Student() { Name = "Ellie", Age = 21 };
            Student student4 = new Student() { Name = "Lovisa", Age = 25 };

            SchoolClass schoolClass = new SchoolClass() { Name = "A1" };
            SchoolClass schoolClass2 = new SchoolClass() { Name = "B2" };

            schoolClass.Students = new List<Student>() { student, student3 };
            schoolClass2.Students = new List<Student>() { student2, student4 };

            dbContext.Student.Add(student);
            dbContext.Student.Add(student2);
            dbContext.Student.Add(student3);
            dbContext.Student.Add(student4);

            dbContext.SchoolClass.Add(schoolClass);
            dbContext.SchoolClass.Add(schoolClass2);

            dbContext.SaveChanges();
        }

        [Route("addCourses")]
        [HttpGet]
        public void AddCourses()
        {
            // SingleOrDefault to retrieve a single element. I can use a
            // lambda expression in the way I'm doing here to get something specific.
            // I am here retrieving a student s with the name I indicate.
            Student student = dbContext.Student.SingleOrDefault(student => student.Name == "Jim");
            Student student2 = dbContext.Student.SingleOrDefault(student => student.Name == "Jake");
            Student student3 = dbContext.Student.SingleOrDefault(student => student.Name == "Ellie");
            Student student4 = dbContext.Student.SingleOrDefault(student => student.Name == "Lovisa");

            Course math = new Course() { Name = "Math" };
            Course java = new Course() { Name = "Java" };
            Course csharp = new Course() { Name = "CSharp" };
            Course historyOfTheMongolianEmpire = new Course() { Name = "History Of The Mongolian Empire" };

            // I make sure the lists on both sides contain the correct elements.
            student.Courses = new List<Course>() { math, historyOfTheMongolianEmpire };
            student4.Courses = new List<Course>() { java, csharp, historyOfTheMongolianEmpire };
            student2.Courses = new List<Course>() { historyOfTheMongolianEmpire };
            student3.Courses = new List<Course>() { math, java };

            math.Students = new List<Student>() { student, student3 };
            java.Students = new List<Student>() { student4, student3 };
            csharp.Students = new List<Student>() { student4 };
            historyOfTheMongolianEmpire.Students = new List<Student>() { student4, student, student2 };

            // When I then add the elements and then save changes, the updates
            // should happen to the database.
            dbContext.Course.Add(math);
            dbContext.Course.Add(java);
            dbContext.Course.Add(csharp);
            dbContext.Course.Add(historyOfTheMongolianEmpire);

            dbContext.SaveChanges();
        }

        [Route("getclasses")]
        [HttpGet]
        public List<SchoolClass> GetClasses()
        {
            // When you want to retrieve more than one table at the
            // same time, you want to first select the the DbSet of
            // the class you want the things from, then Include.
            // With a lambda expression, indicate the list/object that
            // you want to import as well. This will get the classes
            // AND the students that are in them.
            // If you were to include more than one table,
            // we can use ThenInclude to include another.
            return dbContext.SchoolClass.Include(
                    schoolClass => schoolClass.Students
                ).ThenInclude(
                    student => student.Courses
                ).ToList();
        }

        [Route("student")]
        [HttpGet]
        public Student GetStudent(int id)
        {
            // This is a combination of include and singleordefault to only get one.
            return dbContext.Student.Include(
                    student => student.Courses
                ).SingleOrDefault(s => s.Id == id);
        }
    }
}
