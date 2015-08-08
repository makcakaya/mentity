using Mentity.Abstraction;

namespace Mentity.Example.Data
{
    public interface IContextFactory
    {
        IDbContext Create();
    }
}
