using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumdrop.NET.Domain;

namespace Wumdrop.Net.Domain
{
    public class CreateDeliveryRequest : BaseResponse
    {
        
        public string pickup_address
        {
            get;set;
        }

        public string pickup_contact_name
        {
            get;set;
        }

        public string pickup_contact_phone
        {
            get;set;
        }

        public string pickup_remarks
        {
            get;
            set;
        }

        public string dropoff_address
        {
            get;
            set;
        }

        //from here

        public string dropoff_contact_name
        {
            get;
            set;
        }

        public string dropoff_contact_phone
        {
            get;
            set;
        }

        public string dropoff_remarks
        {
            get;
            set;
        }

        public string pickup_coordinates
        {
            get;
            set;
        }

        public string dropoff_coordinates
        {
            get;
            set;
        }
    }
}
