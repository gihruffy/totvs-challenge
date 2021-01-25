using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.ExceptionHandler;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;

namespace TOTVSChallenge.Service.Services.AuctionUseCases.Flow
{
    public class GetAllAuctionFlow : IGetAllAuctionFlow
    {

        private IGetAllAuctionUseCase _getAllAuctionUseCase;

        public GetAllAuctionFlow(
            IGetAllAuctionUseCase getAllAuctionUseCase
        )
        {
            _getAllAuctionUseCase = getAllAuctionUseCase;
        }


        public async Task<IEnumerable<Auction>> Execute()
        {
            try
            {
                return await _getAllAuctionUseCase.Execute();
            }
            catch (TOTVSCustomExcepetion ex)
            {
                throw ex;
            }
        }
    }
}
