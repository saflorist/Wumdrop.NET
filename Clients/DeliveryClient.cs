using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumdrop.NET.Domain;
using Wumdrop.Net.Domain;

namespace Wumdrop.NET.Clients
{
    public class DeliveryClient : BaseClient
    {
        public DeliveryClient(string apiKey)
            : base(Wumdrop.NET.Utilities.Constants.ApiUrl.Deliveries, apiKey)
        {

        }

        public MessageResponse AuthenticationTest()
        {
            var result = CallRestJsonService<MessageResponse>(ApiUrl, null, "GET", ApiKey);
            return result;
        }

        public CreateDeliveryResponse CreateDelivery(CreateDeliveryRequest request)
        {
            var result = CallRestJsonService<CreateDeliveryResponse>(ApiUrl, request, "POST", ApiKey);
            return result;
        }

        public ListDeliveryResponse ListDeliveries()
        {
            var result = CallRestJsonService<ListDeliveryResponse>(ApiUrl, null, "GET", ApiKey);
            return result;
        }


        public GetDeliverySingleResponse GetDeliverySingle(string id)
        {
            var result = CallRestJsonService<GetDeliverySingleResponse>(ApiUrl + "/" + id, null, "GET", ApiKey);
            return result;
        }

        public MessageResponse CancelDelivery(string id)
        {
            var result = CallRestJsonService<MessageResponse>(ApiUrl + "/" + id, null, "DELETE", ApiKey);
            return result;
        }


    }

   
}
