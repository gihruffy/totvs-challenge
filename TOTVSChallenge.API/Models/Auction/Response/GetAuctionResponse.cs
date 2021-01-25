using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOTVSChallenge.API.Models.User.Response;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.API.Models.Auction.Response
{
    public class GetAuctionResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal InitialValue { get; set; }
        public Boolean Used { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public GetUserResponse User { get; set; }


        public static GetAuctionResponse Create(
            int id,
            int userId,
            string name,
            decimal initialValue,
            bool used,
            DateTime startDate,
            GetUserResponse user,
            DateTime endDate) => new GetAuctionResponse()
            {
                Id = id,
                UserId = userId,
                Name = name,
                InitialValue = initialValue,
                Used = used,
                StartDate = startDate,
                EndDate = endDate,
                User = user
            };

        public static GetAuctionResponse Create() => new GetAuctionResponse() { };
    }
}
