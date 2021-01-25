using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Respository.Database.Context;

namespace TOTVSChallenge.Respository.Database.Repositories
{
    public class AuctionRepository : BaseRepository<Auction>, IAuctionRepository
    {
        public AuctionRepository(TOTVSChallengeContext context) : base(context) { }

        public async Task<Auction> Delete(int Id)
        {
            Auction item =  await NoTracking().FirstOrDefaultAsync(x => x.Id == Id);
            DbSet.Remove(item);
            return item;
        }

        public async Task<IEnumerable<Auction>> FindAll() => await NoTracking().Include(x => x.UserReference).ToListAsync();
        

        public async Task<Auction> FindById(int Id) => await NoTracking().FirstOrDefaultAsync(x => x.Id == Id);

        public async Task<Auction> GetByIdAsync(int id, int userId) => 
            await NoTracking()
            .Include(x => x.UserReference)
            .Where(x => x.Id == id && x.UserId == x.UserId)
            .FirstOrDefaultAsync();
        

        public async Task<Auction> GetByIdAsync(int id) => await NoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}
