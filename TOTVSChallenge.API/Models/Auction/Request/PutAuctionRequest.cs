using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOTVSChallenge.API.Models.Auction.Request
{
    public class PutAuctionRequest
    {
        public int UserId { get;  set; }
        public string Name { get;  set; }
        public decimal InitialValue { get;  set; }
        public Boolean Used { get;  set; }

        public DateTime StartDate { get;  set; }

        public DateTime EndDate { get;  set; }


        public static PutAuctionRequest Create(
            int userId,
            string name,
            decimal initialValue,
            bool used,
            DateTime startDate,
            DateTime endDate) => new PutAuctionRequest()
            {
                UserId = userId,
                Name = name,
                InitialValue = initialValue,
                Used = used,
                StartDate = startDate,
                EndDate = endDate
            };
    }

    public class PutAuctionRequestValidator : AbstractValidator<PutAuctionRequest>
    {
        public PutAuctionRequestValidator()
        {

            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty")
                .NotNull().WithMessage("UserId cannot be null");

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null");

            RuleFor(e => e.InitialValue)
                .NotEmpty().WithMessage("InitialValue cannot be empty")
                .NotNull().WithMessage("InitialValue cannot be null");

            RuleFor(e => e.Used)
                .NotEmpty().WithMessage("Used cannot be empty")
                .NotNull().WithMessage("Used cannot be null");

            RuleFor(e => e.StartDate)
                .NotEmpty().WithMessage("StartDate cannot be empty")
                .NotNull().WithMessage("StartDate cannot be null");

            RuleFor(e => e.EndDate)
                .NotEmpty().WithMessage("EndDate cannot be empty")
                .NotNull().WithMessage("EndDate cannot be null");

        }
    }
}
