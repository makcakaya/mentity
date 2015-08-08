using System.Collections.Generic;

namespace Mentity.Example.Domain
{
    public sealed class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Major Major { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
