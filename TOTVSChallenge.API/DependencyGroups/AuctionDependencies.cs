using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;
using TOTVSChallenge.Respository.Database.Repositories;
using TOTVSChallenge.Service.Services.AuctionUseCases.Flow;
using TOTVSChallenge.Service.Services.AuctionUseCases.UseCase;

namespace TOTVSChallenge.API.DependencyGroups
{
    public static class AuctionDependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICreateAuctionFlow, CreateAuctionFlow>();
            services.AddScoped<IUpdateAuctionFlow, UpdateAuctionFlow>();
            services.AddScoped<IDeleteAuctionFlow, DeleteAuctionFlow>();
            services.AddScoped<IGetAllAuctionFlow, GetAllAuctionFlow>();
            services.AddScoped<IGetByIdAuctionFlow, GetByIdAuctionFlow>();


            services.AddScoped<ICreateAuctionUseCase, CreateAuctionUseCase>();
            services.AddScoped<IUpdateAuctionUseCase, UpdateAuctionUseCase>();
            services.AddScoped<IDeleteAuctionUseCase, DeleteAuctionUseCase>();
            services.AddScoped<IGetAllAuctionUseCase, GetAllAuctionUseCase>();
            services.AddScoped<IGetByIdAuctionUseCase, GetByIdAuctionUseCase>();


            services.AddScoped<IAuctionRepository, AuctionRepository>();



        }

    }
}
