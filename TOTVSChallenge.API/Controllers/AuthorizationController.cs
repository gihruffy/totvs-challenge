using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.Authenticate.Request;
using TOTVSChallenge.API.Translate.Authenticate.Response;
using TOTVSChallenge.Domain.Interfaces.Services.AuthorizationUseCases.Flow;

namespace TOTVSChallenge.API.Controllers
{
    public class AuthorizationController : Controller
    {
        private IAuthorizationFlow _authorizationFlow;
        public AuthorizationController(IAuthorizationFlow authorizationFlow)
        {
            _authorizationFlow = authorizationFlow;
        }

        [HttpPost("TOTVSChallenge/api/authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] PostAuthenticateRequest model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authorizationFlow.Execute(model.Username, model.Password);
            var translatedResponse = AuthorizationDtoToPostAuthenticateResponse.Translate(response);                

            return Ok(translatedResponse);
        }
    }
}
