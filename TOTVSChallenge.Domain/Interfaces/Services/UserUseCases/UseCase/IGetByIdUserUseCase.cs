using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.UseCase
{
    public interface IGetByIdUserUseCase
    {
        Task<User> Execute(int id);
    }
}
