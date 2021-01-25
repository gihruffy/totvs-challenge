using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TOTVSChallenge.Domain.Interfaces.Services
{
    public interface IUnitOfWork: IDisposable
    {
        bool SaveChanges();

        Task<bool> SaveChangesAsync();
    }
}
