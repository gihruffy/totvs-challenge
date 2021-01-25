using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.Auction.Response;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.API.Translate.AuctionTranslate.Response
{
    public class GetAllAuctionEntityToListAuctionResponse
    {
        public static List<GetAuctionResponse> Translate (IEnumerable<Auction> entitys) => 
            entitys != null ? entitys.ToList().ConvertAll(x => GetAuctionEntityToGetAuctionResponse.Translate(x)) 
            : new List<GetAuctionResponse>();
    }
}
