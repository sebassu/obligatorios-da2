using System;

namespace Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        void SaveChanges();
        void DeleteAllDataFromDatabase();
    }
}