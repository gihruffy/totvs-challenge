using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.Auction.Response;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.API.Translate.AuctionTranslate.Response
{
    public class PostAuctionEntityToPostAuctionResponse
    {
        public static PostAuctionResponse Translate(Auction entity) =>
            entity != null ? PostAuctionResponse.Create(
                id: entity.Id,
                userId: entity.UserId,
                name: entity.Name,
                initialValue: entity.InitialValue,
                used: entity.Used,
                startDate: entity.StartDate,
                endDate: entity.EndDate
            ) : PostAuctionResponse.Create();


    }
}
