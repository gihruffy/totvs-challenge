using System.Threading.Tasks;
using TOTVSChallenge.Domain.Dto;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.ExceptionHandler;
using TOTVSChallenge.Domain.Interfaces.Services.AuthorizationUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuthorizationUseCases.UseCase;
using TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.UseCase;

namespace TOTVSChallenge.Service.Services.AuthorizationUseCases.Flow
{
    public class AuthorizationFlow : IAuthorizationFlow
    {
        private IGenerateAuthorizationTokenUseCase _generateAuthorizationTokenUseCase;
        private IGetByUserNameAndPasswordUserUseCase _getByUserNameAndPasswordUserUseCase;
        public AuthorizationFlow(IGenerateAuthorizationTokenUseCase generateAuthorizationTokenUseCase,
            IGetByUserNameAndPasswordUserUseCase getByUserNameAndPasswordUserUseCase)
        {
            _getByUserNameAndPasswordUserUseCase = getByUserNameAndPasswordUserUseCase;
            _generateAuthorizationTokenUseCase = generateAuthorizationTokenUseCase;
        }

        public async Task<AuthorizationDto> Execute(string username, string password)
        {
            try
            {
                var user = await _getByUserNameAndPasswordUserUseCase.Execute(username, password);
                if (user == null)
                    throw new TOTVSCustomExcepetion(System.Net.HttpStatusCode.NotFound, "Invalid Credentials");
                
                string token = await _generateAuthorizationTokenUseCase.Execute(user);
                return AuthorizationDto.Create(user, token);
               
            }
            catch (TOTVSCustomExcepetion ex)
            {
                throw ex;
            }
        }
    }
}
