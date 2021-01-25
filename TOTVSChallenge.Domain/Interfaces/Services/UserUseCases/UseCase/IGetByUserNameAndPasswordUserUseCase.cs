using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.UseCase
{
    public interface IGetByUserNameAndPasswordUserUseCase
    {
        Task<User> Execute(string username, string password);
    }
}
