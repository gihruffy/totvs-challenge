using System;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.UseCase;

namespace TOTVSChallenge.Service.Services.UserUseCases.UseCase
{
    public class GetByIdUserUseCase : IGetByIdUserUseCase
    {
        private IUserRepository _userRespository;
        public GetByIdUserUseCase(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }
        public async Task<User> Execute(int id)
        {
            return await _userRespository.GetById(id);
        }
    }
}
