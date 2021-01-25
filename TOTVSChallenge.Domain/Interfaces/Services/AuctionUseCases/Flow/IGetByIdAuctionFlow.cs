using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow
{
    public interface IGetByIdAuctionFlow
    {
        Task<Auction> Execute(int id);
    }
}
