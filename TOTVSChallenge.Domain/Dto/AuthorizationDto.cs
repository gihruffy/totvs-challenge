using System;
using System.Collections.Generic;
using System.Text;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Dto
{
    public class AuthorizationDto
    {
        public User User { get; set; }
        public string Token { get; set; }

        public static AuthorizationDto Create(User user, string token) => new AuthorizationDto() { User = user, Token = token };
    }
}
