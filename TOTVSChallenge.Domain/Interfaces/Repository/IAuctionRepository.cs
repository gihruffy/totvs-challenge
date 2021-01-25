using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Repository
{
    public interface IAuctionRepository
    {
        Auction Save(Auction auction);
        Task<ICollection<Auction>> FindByAsync(Expression<Func<Auction, bool>> predicate);
        Task<Auction> GetByIdAsync(int id, int userId);
        Task<Auction> GetByIdAsync(int id);

        Task DeleteAsync(int identifier);
        Task DeleteAsync(Expression<Func<Auction, bool>> predicate);
        Task<Auction> FindById(int Id);
        Task<IEnumerable<Auction>> FindAll();
        Task<Auction> Delete(int Id);

    }
}
