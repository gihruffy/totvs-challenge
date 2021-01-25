using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Repository;
using TOTVSChallenge.Respository.Database.Context;

namespace TOTVSChallenge.Respository.Database.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TOTVSChallengeContext context) : base(context) { }
        public async Task<User> Get(string username, string password) => 
            await NoTracking()
            .Where(x => x.IsActive == true)
            .Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password)
            .FirstOrDefaultAsync();

        public async Task<User> GetById(int id) => 
            await NoTracking()
            .Where(x => x.IsActive == true)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
       
    }
}
