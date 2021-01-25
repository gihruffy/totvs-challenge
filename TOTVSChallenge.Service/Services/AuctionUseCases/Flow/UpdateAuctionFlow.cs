using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.ExceptionHandler;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;

namespace TOTVSChallenge.Service.Services.AuctionUseCases.Flow
{
    public class UpdateAuctionFlow : IUpdateAuctionFlow
    {

        private IUpdateAuctionUseCase _updateAuctionUseCase;
        private IGetByIdAuctionUseCase _getByIdAuctionUseCase;


        public UpdateAuctionFlow(
            IUpdateAuctionUseCase updateAuctionUseCase,
            IGetByIdAuctionUseCase getByIdAuctionUseCase
        )
        {
            _getByIdAuctionUseCase = getByIdAuctionUseCase;
            _updateAuctionUseCase = updateAuctionUseCase;
        }


        public async Task<Auction> Execute(Auction entity, int id)
        {
            try
            {
                Auction auction = await _getByIdAuctionUseCase.Execute(id);

                if (auction == null)
                    throw new ValidationException("Invalid Auction ID");

                auction.PrepareUpdate(entity);

                return await _updateAuctionUseCase.Execute(auction);
            }
            catch (TOTVSCustomExcepetion ex)
            {
                throw ex;
            }
        }
    }
}
