using System;
using System.Collections.Generic;
using System.Text;

namespace TOTVSChallenge.Domain.Entities
{
    public class User: EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set;  }
        public virtual Auction AuctionReference { get; private set; }


        public static User Create(int id, string username, string password, string role, bool isActive) => new User()
        {
            Id = id,
            Username = username,
            Password = password,
            Role = role,
            IsActive = isActive
        }; 
    }

}
