using System;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.ExceptionHandler;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;


namespace TOTVSChallenge.Service.Services.AuctionUseCases.Flow
{
    public class CreateAuctionFlow: ICreateAuctionFlow
    {

        private ICreateAuctionUseCase _createAuctionUseCase;

        public CreateAuctionFlow(
            ICreateAuctionUseCase createAuctionUseCase
        )
        {
            _createAuctionUseCase = createAuctionUseCase;
        }


        public async Task<Auction> Execute(Auction entity)
        {
            try
            {
                return await _createAuctionUseCase.Execute(entity);
            }
            catch (TOTVSCustomExcepetion ex)
            {
                throw ex;
            }
        }
    }
}
