using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.Auction.Response;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.API.Translate.AuctionTranslate.Response
{
    public class PutAuctionEntityToPutAuctionResponse
    {
        public static PutAuctionResponse Translate(Auction entity) =>
            entity != null ? PutAuctionResponse.Create(
                id: entity.Id,
                userId: entity.UserId,
                name: entity.Name,
                initialValue: entity.InitialValue,
                used: entity.Used,
                startDate: entity.StartDate,
                endDate: entity.EndDate
            ) : PutAuctionResponse.Create();


    }
}
