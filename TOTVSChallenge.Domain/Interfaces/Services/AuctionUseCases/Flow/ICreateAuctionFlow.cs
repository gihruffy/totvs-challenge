﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TOTVSChallenge.Domain.Entities;

namespace TOTVSChallenge.Domain.Interfaces.Services.AuctionUseCases.Flow
{
    public interface ICreateAuctionFlow
    {
        Task<Auction> Execute(Auction entity);
    }
}
