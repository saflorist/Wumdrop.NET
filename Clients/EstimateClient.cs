using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumdrop.NET.Clients;
using Wumdrop.NET.Domain;
using Wumdrop.Net.Domain;
using Wumdrop.NET.Utilities;

namespace Wumdrop.Net.Clients
{
    public class EstimateClient : BaseClient
    {
        public EstimateClient(string apiKey)
            : base(Constants.ApiUrl.Estimates, apiKey)
        {

        }

        public QuoteResponse GetQuote(QuoteRequest request)
        {
            var result = CallRestJsonService<QuoteResponse>(ApiUrl + string.Format("/quote?lat1={0}&lon1={1}&lat2={2}&lon2={3}", request.lat1, request.lon1, request.lat2, request.lon2), null, "GET", ApiKey);
            return result;
        }


        


    }
}
