using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumdrop.NET.Domain;

namespace Wumdrop.Net.Domain
{
    public class GetDeliverySingleResponse : BaseResponse
    {
        public string driver_id { get; set; }
        public string dropoff_address { get; set; }
        public string dropoff_coordinates { get; set; }
        public string dropoff_timestamp { get; set; }
        public string id { get; set; }
        public string pickup_address { get; set; }
        public string pickup_coordinates { get; set; }
        public string pickup_timestamp { get; set; }
        public string status { get; set; }
        public string time_estimate { get; set; }
    }
}
