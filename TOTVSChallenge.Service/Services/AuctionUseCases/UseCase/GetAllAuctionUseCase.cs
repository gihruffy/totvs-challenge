using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;


namespace TOTVSChallenge.Service.Services.AuctionUseCases.UseCase
{
    public class GetAllAuctionUseCase : IGetAllAuctionUseCase
    {   
        private IAuctionRepository _auctionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllAuctionUseCase(IAuctionRepository auctionRepository,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _auctionRepository = auctionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Auction>> Execute()
        {
            var context = _httpContextAccessor.HttpContext;
            return await _auctionRepository.FindAll();
        }
    }
}
