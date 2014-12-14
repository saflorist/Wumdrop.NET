using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumdrop.NET.Domain;

namespace Wumdrop.Net.Domain
{
    public class ListDeliveryResponse : BaseResponse
    {
        public IEnumerable<DeliveryState> deliveries { get; set; }
    }
}
