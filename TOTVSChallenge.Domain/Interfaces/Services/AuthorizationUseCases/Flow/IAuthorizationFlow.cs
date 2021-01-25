using System.Threading.Tasks;
using TOTVSChallenge.Domain.Dto;

namespace TOTVSChallenge.Domain.Interfaces.Services.AuthorizationUseCases.Flow
{
    public interface IAuthorizationFlow
    {
        Task<AuthorizationDto> Execute(string username, string password);
    }
}
