using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.Authenticate.Response;
using TOTVSChallenge.Domain.Dto;

namespace TOTVSChallenge.API.Translate.Authenticate.Response
{
    public static class AuthorizationDtoToPostAuthenticateResponse
    {
        public static PostAuthenticateResponse Translate(AuthorizationDto dto) =>
            dto != null ? PostAuthenticateResponse.Create(dto.User, dto.Token) : PostAuthenticateResponse.Create();
    }
}
