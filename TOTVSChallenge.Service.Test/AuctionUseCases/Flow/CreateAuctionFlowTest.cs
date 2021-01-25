using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow;
using TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.UseCase;
using TOTVSChallenge.Service.Services.AuctionUseCases.Flow;
using Xunit;

namespace TOTVSChallenge.Service.Test.AuctionUseCases.Flow
{

    public class CreateAuctionFlowTest
    {
        private ICreateAuctionFlow _createAuctionFlow;
        private Mock<ICreateAuctionUseCase> _createActionUseCase { get; set; }
        public CreateAuctionFlowTest()
        {
            _createActionUseCase = new Mock<ICreateAuctionUseCase>();
            this._createAuctionFlow = new CreateAuctionFlow(_createActionUseCase.Object);
        }

        private Auction MockAuction()
        {
            return Auction.Create(userId: 1, "Mocked", initialValue: 100, startDate: DateTime.Now, endDate: DateTime.Now, used: false);
        }

        [Fact]
        public void CreateAuctionFlowShouldReturnSuccess()
        {
            Auction mockAuction = this.MockAuction();
            this._createActionUseCase
                .Setup(b => b.Execute(mockAuction)).ReturnsAsync(It.IsAny<Auction>());
           
            var exception = Record.ExceptionAsync(() => _createAuctionFlow.Execute(mockAuction)).Result;

            Assert.Null(exception);

        }

    }
}
