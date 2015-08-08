using Mentity.Concrete;
using Mentity.Example.Domain;
using System.Data.Entity;

namespace Mentity.Example.Data
{
    public sealed class ExampleContext : ContextBase
    {
        public IDbSet<Course> Course { get; set; }
        public IDbSet<Student> Student { get; set; }

        public ExampleContext() : base()
        {

        }

        public ExampleContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}
