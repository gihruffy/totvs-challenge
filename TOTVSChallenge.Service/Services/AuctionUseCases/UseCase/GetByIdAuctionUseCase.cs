using Microsoft.AspNetCore.Http;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;


namespace TOTVSChallenge.Service.Services.AuctionUseCases.UseCase
{
    public class GetByIdAuctionUseCase : IGetByIdAuctionUseCase
    {   
        private IAuctionRepository _auctionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public GetByIdAuctionUseCase(IAuctionRepository auctionRepository,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _auctionRepository = auctionRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Auction> Execute(int id)
        {
            var context = _httpContextAccessor.HttpContext;
            User user = (User)context.Items["User"];
            var auction = await _auctionRepository.GetByIdAsync(id, user.Id);
            return auction;
        }
    }
}
