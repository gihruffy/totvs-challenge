using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;


namespace TOTVSChallenge.Service.Services.AuctionUseCases.UseCase
{
    public class DeleteAuctionUseCase : IDeleteAuctionUseCase
    {   
        private IAuctionRepository _auctionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuctionUseCase(IAuctionRepository auctionRepository,
            IUnitOfWork unitOfWork)
        {
            _auctionRepository = auctionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Auction> Execute(int id)
        {
            var entity = await _auctionRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
