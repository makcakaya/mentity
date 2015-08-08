using System.Collections.Generic;

namespace Mentity.Example.Domain
{
    public sealed class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Major> ValidMajors { get; set; }
    }
}
