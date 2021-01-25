using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;


namespace TOTVSChallenge.Service.Services.AuctionUseCases.UseCase
{
    public class UpdateAuctionUseCase : IUpdateAuctionUseCase
    {   
        private IAuctionRepository _auctionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuctionUseCase(IAuctionRepository auctionRepository,
            IUnitOfWork unitOfWork)
        {
            _auctionRepository = auctionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Auction> Execute(Auction entity)
        {
            var savedAuction = _auctionRepository.Save(entity);
            await _unitOfWork.SaveChangesAsync();
            return savedAuction;
        }
    }
}
