using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.ExceptionHandler;
using TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.UserUseCases.UseCase;

namespace TOTVSChallenge.Service.Services.UserUseCases.Flow
{
    public class GetByIdUserFlow : IGetByIdUserFlow
    {
        private IGetByIdUserUseCase _getByIdUserUseCase;
        public GetByIdUserFlow(IGetByIdUserUseCase getByIdUserUseCase)
        {
            _getByIdUserUseCase = getByIdUserUseCase;
        }
        public async Task<User> Execute(int id)
        {
            try
            {
                return await _getByIdUserUseCase.Execute(id);
            }
            catch (TOTVSCustomExcepetion ex)
            {
                throw ex;
            }
        }
    }
}
