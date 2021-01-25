using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase
{
    public interface IGetByIdAuctionUseCase
    {
        Task<Auction> Execute(int id);
    }
}
