using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.ExceptionHandler;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;


namespace TOTVSChallenge.Service.Services.AuctionUseCases.Flow
{
    public class DeleteAuctionFlow : IDeleteAuctionFlow
    {

        private IDeleteAuctionUseCase _deleteAuctionUseCase;
        private IGetByIdAuctionUseCase _getByIdAuctionUseCase;

        public DeleteAuctionFlow(
            IDeleteAuctionUseCase deleteAuctionUseCase,
            IGetByIdAuctionUseCase getByIdAuctionUseCase
        )
        {
            _getByIdAuctionUseCase = getByIdAuctionUseCase;
            _deleteAuctionUseCase = deleteAuctionUseCase;
        }


        public async Task<Auction> Execute(int id)
        {
            try
            {
                Auction auction = await _getByIdAuctionUseCase.Execute(id);

                if (auction == null)
                    throw new ValidationException("Invalid Auction ID");

                return await _deleteAuctionUseCase.Execute(id);
            }
            catch (TOTVSCustomExcepetion ex)
            {
                throw ex;
            }
        }
    }
}
