using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumdrop.NET.Domain;

namespace Wumdrop.Net.Domain
{
    public class QuoteResponse : BaseResponse
    {
        public double distance { get; set; }
        public decimal price { get; set; }
        public double time { get; set; }
    }
}
