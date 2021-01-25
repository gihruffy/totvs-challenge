using TOTVSChallenge.Domain.Interfaces.Services;
using TOTVSChallenge.Respository.Database.Context;
using System;
using System.Threading.Tasks;

namespace TOTVSChallenge.Respository.Database.Transacions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TOTVSChallengeContext _context;

        public UnitOfWork(TOTVSChallengeContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }

}
