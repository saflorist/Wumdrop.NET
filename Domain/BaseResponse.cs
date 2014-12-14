using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wumdrop.NET.Domain
{
    public class BaseResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}
