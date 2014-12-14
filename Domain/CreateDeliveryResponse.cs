using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumdrop.NET.Domain;

namespace Wumdrop.Net.Domain
{
    public class CreateDeliveryResponse : BaseResponse
    {
        public int distance_estimate
        {
            get; set;
        }

        public string id
        {
            get;
            set;
        }

        public string message
        {
            get;
            set;
        }

        public decimal price
        {
            get;
            set;
        }

        public int time_estimate
        {
            get;
            set;
        }
    }
}
