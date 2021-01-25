using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.Auction.Request;
using TOTVSChallenge.API.Models.Auction.Response;
using TOTVSChallenge.API.Translate.AuctionTranslate.Request;
using TOTVSChallenge.API.Translate.AuctionTranslate.Response;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow;

namespace TOTVSChallenge.API.Controllers
{
    [ApiController]
    public class AuctionController : Controller
    {
        private ICreateAuctionFlow _createAuctionFlow;
        private IUpdateAuctionFlow _updateAuctionFlow;
        private IGetAllAuctionFlow _getAllAuctionFlow;
        private IGetByIdAuctionFlow _getByIdAuctionFlow;
        private IDeleteAuctionFlow _deleteAuctionFlow;

        public AuctionController(
            ICreateAuctionFlow createAuctionFlow,
            IUpdateAuctionFlow updateAuctionFlow,
            IGetAllAuctionFlow getAllAuctionFlow,
            IGetByIdAuctionFlow getByIdAuctionFlow,
            IDeleteAuctionFlow deleteAuctionFlow
            )
        {
            _createAuctionFlow = createAuctionFlow;
            _updateAuctionFlow = updateAuctionFlow;
            _getAllAuctionFlow = getAllAuctionFlow;
            _getByIdAuctionFlow = getByIdAuctionFlow;
            _deleteAuctionFlow = deleteAuctionFlow;
        }

        [Authorize]
        [HttpGet("TOTVSChallenge/api/auction")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(List<GetAuctionResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _getAllAuctionFlow.Execute();
            var translateResponse = GetAllAuctionEntityToListAuctionResponse.Translate(response);

            return Ok(translateResponse);
        }

        [Authorize]
        [HttpGet("TOTVSChallenge/api/auction/{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(GetAuctionResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _getByIdAuctionFlow.Execute(id);
            var translateResponse = GetAuctionEntityToGetAuctionResponse.Translate(response);

            return Ok(translateResponse);
        }

        [Authorize]
        [HttpPost("TOTVSChallenge/api/auction")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PostAuctionResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> PostAuction([FromBody] PostAuctionRequest model)
        {
            var response = await _createAuctionFlow.Execute(PostAuctionRequestToAuctionEntity.Translate(model));
            var translateResponse = PostAuctionEntityToPostAuctionResponse.Translate(response);

            return Ok(translateResponse);
        }

        [Authorize]
        [HttpPut("TOTVSChallenge/api/auction/{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PutAuctionResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> PutAuction([FromRoute][Required] int id, [FromBody] PutAuctionRequest model)
        {
            var response = await _updateAuctionFlow.Execute(PutAuctionRequestToAuctionEntity.Translate(model), id);
            var translateResponse = PostAuctionEntityToPostAuctionResponse.Translate(response);

            return Ok(translateResponse);
        }

        [Authorize]
        [HttpDelete("TOTVSChallenge/api/auction/{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteAuction([FromRoute][Required] int id)
        {
            var response = await _deleteAuctionFlow.Execute(id);

            return Ok(true);
        }


    }
}
