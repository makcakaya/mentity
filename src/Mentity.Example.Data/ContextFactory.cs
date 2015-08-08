using Mentity.Abstraction;

namespace Mentity.Example.Data
{
    public sealed class ContextFactory : IContextFactory
    {
        public IDbContext Create()
        {
            return new ExampleContext();
        }
    }
}
