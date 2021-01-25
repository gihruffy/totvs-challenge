using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.UseCase;

namespace TOTVSChallenge.Service.Services.UserUseCases.UseCase
{
    public class GetByUserNameAndPasswordUserUseCase : IGetByUserNameAndPasswordUserUseCase
    {
        private IUserRepository _userRespository;
        public GetByUserNameAndPasswordUserUseCase(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }
        public async Task<User> Execute(string username, string password)
        {
            return await _userRespository.Get(username, password);
        }
    }
}
