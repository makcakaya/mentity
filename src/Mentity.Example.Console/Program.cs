using Mentity.Example.Data;
using Mentity.Example.Domain;
using System.Linq;

namespace Mentity.Example.Console
{
    class Program
    {
        private static readonly IContextFactory _contextFactory = new ContextFactory();

        static void Main(string[] args)
        {
            int studentId = 0;
            using (var context = _contextFactory.Create())
            {
                context.Database.Initialize(false);
                var student = new Student
                {
                    Major = Major.ComputerScience,
                    Name = "Bill Gates",
                };

                student = context.Repo<Student>().Add(student);

                var course = new Course
                {
                    Name = "Operating Systems",
                    ValidMajors = new Major[] { Major.ComputerScience, Major.Math },
                };

                course = context.Repo<Course>().Add(course);
                student.Courses = new Course[] { course };

                context.SaveChanges();
                studentId = student.Id;
            }

            using (var context = _contextFactory.Create())
            {
                var loadedStudent = context.Repo<Student>().Include(s => s.Courses).First(s => s.Id == studentId);
                System.Console.WriteLine("Loaded student with Id: {0}, Name: {1}", loadedStudent.Id, loadedStudent.Name);
            }
        }
    }
}
