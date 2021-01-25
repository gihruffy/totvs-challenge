using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOTVSChallenge.API.Models.Auction.Response
{
    public class PostAuctionResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal InitialValue { get; set; }
        public Boolean Used { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public static PostAuctionResponse Create(
            int id,
            int userId,
            string name,
            decimal initialValue,
            bool used,
            DateTime startDate,
            DateTime endDate) => new PostAuctionResponse()
            {
                Id = id,
                UserId = userId,
                Name = name,
                InitialValue = initialValue,
                Used = used,
                StartDate = startDate,
                EndDate = endDate
            };

        public static PostAuctionResponse Create() => new PostAuctionResponse() { };
    }
}
