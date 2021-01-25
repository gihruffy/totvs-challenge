using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.Auction.Response;
using TOTVSChallenge.API.Models.User.Response;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.API.Translate.AuctionTranslate.Response
{
    public class GetAuctionEntityToGetAuctionResponse
    {
        public static GetAuctionResponse Translate(Auction entity) =>
            entity != null ? GetAuctionResponse.Create(
                id: entity.Id,
                userId: entity.UserId,
                name: entity.Name,
                initialValue: entity.InitialValue,
                used: entity.Used,
                startDate: entity.StartDate,
                endDate: entity.EndDate,
                user: GetUserResponse.Create(id: entity.UserReference.Id, username: entity.UserReference.Username, role: entity.UserReference.Role)
            ) : GetAuctionResponse.Create();


    }
}
