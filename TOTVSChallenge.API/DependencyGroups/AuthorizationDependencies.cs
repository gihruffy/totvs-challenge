using Microsoft.Extensions.DependencyInjection;
using TOTVSChallenge.Domain.Interfaces.Services.AuthorizationUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuthorizationUseCases.UseCase;
using TOTVSChallenge.Service.Services.AuthorizationUseCases.Flow;
using TOTVSChallenge.Service.Services.AuthorizationUseCases.UseCase;

namespace TOTVSChallenge.API.DependencyGroups
{
    public static class AuthorizationDependencies
    {
        public static void AddDependencies(
          this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationFlow, AuthorizationFlow>();
            services.AddScoped<IGenerateAuthorizationTokenUseCase, GenerateAuthorizationTokenUseCase>();
        }
    }
}
