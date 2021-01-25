using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.API.Models.Authenticate.Response
{
    public class PostAuthenticateResponse
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }


        public static PostAuthenticateResponse Create(TOTVSChallenge.Domain.Entities.User user, string token) => new PostAuthenticateResponse()
        {
            Id = user.Id,
            UserName = user.Username,
            Role = user.Role,
            Token = token
        };
        public static PostAuthenticateResponse Create() => new PostAuthenticateResponse() { };

    }
}
