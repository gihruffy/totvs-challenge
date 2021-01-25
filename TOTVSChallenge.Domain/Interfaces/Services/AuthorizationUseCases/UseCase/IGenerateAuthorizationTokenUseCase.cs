using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Services.AuthorizationUseCases.UseCase
{
    public interface IGenerateAuthorizationTokenUseCase
    {
        Task<string> Execute(User user);
    }
}
