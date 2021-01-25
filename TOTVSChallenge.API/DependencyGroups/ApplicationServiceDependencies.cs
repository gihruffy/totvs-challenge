using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace TOTVSChallenge.API.DependencyGroups
{
    public static class ApplicationServiceDependencies
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            AuctionDependencies.AddDependencies(services);
            UserDependencies.AddDependencies(services);
            AuthorizationDependencies.AddDependencies(services);
        }

    }
}
