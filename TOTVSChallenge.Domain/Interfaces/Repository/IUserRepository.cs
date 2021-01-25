using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> Get(string username, string password);
        Task<User> GetById(int id);


    }
}
