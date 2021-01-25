using System;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.ExceptionHandler;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;


namespace TOTVSChallenge.Service.Services.AuctionUseCases.Flow
{
    public class GetByIdAuctionFlow : IGetByIdAuctionFlow
    {

        private IGetByIdAuctionUseCase _getByIdAuctionUseCase;

        public GetByIdAuctionFlow(
            IGetByIdAuctionUseCase getByIdAuctionUseCase
        )
        {
            _getByIdAuctionUseCase = getByIdAuctionUseCase;
        }


        public async Task<Auction> Execute(int id)
        {
            try
            {
                return await _getByIdAuctionUseCase.Execute(id);
            }
            catch (TOTVSCustomExcepetion ex)
            {
                throw ex;
            }
        }
    }
}
