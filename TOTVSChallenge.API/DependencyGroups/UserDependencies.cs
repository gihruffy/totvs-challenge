using Microsoft.Extensions.DependencyInjection;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.UseCase;
using TOTVSChallenge.Respository.Database.Repositories;
using TOTVSChallenge.Service.Services.UserUseCases.Flow;
using TOTVSChallenge.Service.Services.UserUseCases.UseCase;

namespace TOTVSChallenge.API.DependencyGroups
{
    public static class UserDependencies
    {
        public static void AddDependencies(
           this IServiceCollection services)
        {
            services.AddScoped<IGetByIdUserFlow, GetByIdUserFlow>();
            services.AddScoped<IGetByIdUserUseCase, GetByIdUserUseCase>();
            services.AddScoped<IGetByUserNameAndPasswordUserUseCase, GetByUserNameAndPasswordUserUseCase>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
