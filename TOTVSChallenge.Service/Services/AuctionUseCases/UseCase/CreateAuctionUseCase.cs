using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;


namespace TOTVSChallenge.Service.Services.AuctionUseCases.UseCase
{
    public class CreateAuctionUseCase : ICreateAuctionUseCase
    {   
        private IAuctionRepository _auctionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CreateAuctionUseCase(IAuctionRepository auctionRepository,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _auctionRepository = auctionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Auction> Execute(Auction entity)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var user = (User) httpContext.Items["User"];
            entity.SetUser(user.Id);
            var savedAuction = _auctionRepository.Save(entity);
            await _unitOfWork.SaveChangesAsync();
            return savedAuction;
            
        }
    }
}
