using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumdrop.NET.Utilities
{
    public class Constants
    {
        public sealed class ApiUrl
        {
            public static readonly string AuthenticationTest = "https://api.wumdrop.com/v1/test";
            public static readonly string Deliveries = "https://api.wumdrop.com/v1/deliveries";
            public static readonly string Estimates = "https://api.wumdrop.com/v1/estimates";
        }

        public sealed class State
        {
            public static readonly string Pending = "PENDING";
            public static readonly string Pickup = "PICKUP";
            public static readonly string PendingDropoff = "PENDING DROPOFF";
            public static readonly string Delivered = "DELIVERED";
            public static readonly string Cancelled = "CANCELLED";
            
        }
    }

    
}
