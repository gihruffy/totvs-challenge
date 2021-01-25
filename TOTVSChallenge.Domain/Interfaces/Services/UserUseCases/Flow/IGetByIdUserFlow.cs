using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.Flow
{
    public interface IGetByIdUserFlow
    {
        Task<User> Execute(int id);
    }
}
