using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOTVSChallenge.API.Models.User.Response
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public static GetUserResponse Create(int id, string username, string role) => new GetUserResponse()
        {
            Id = id,
            UserName = username,
            Role = role,
        };

        public static GetUserResponse Create() => new GetUserResponse() { };
    }
}
