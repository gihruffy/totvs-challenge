using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.Auction.Request;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.API.Translate.AuctionTranslate.Request
{
    public class PostAuctionRequestToAuctionEntity
    {
        public static Auction Translate(PostAuctionRequest model) =>
            model != null ? Auction.Create(
                userId: model.UserId,
                name: model.Name,
                initialValue: model.InitialValue,
                used: model.Used,
                startDate: model.StartDate,
                endDate: model.EndDate
            ) : Auction.Create();
    }
}
