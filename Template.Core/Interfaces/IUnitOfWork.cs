
using Template.Core.Interfaces;

namespace Template.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {


        void SaveChanges();

        Task SaveChangesAsync();

    }
}
