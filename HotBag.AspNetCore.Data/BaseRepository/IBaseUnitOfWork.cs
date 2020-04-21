using System;
using System.Threading.Tasks;

namespace HotBag.AspNetCore.Data.BaseRepository
{
    public interface IBaseUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}