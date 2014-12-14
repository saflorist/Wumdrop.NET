using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Wumdrop.Net.Clients;
using Wumdrop.NET.Clients;
using Wumdrop.Net.Domain;
using Wumdrop.NET.Domain;

namespace Tests
{
    [TestFixture]
    public class WumdropTests
    {
        public const string WumdropApiKey = "7fb910add835b928c8078d9966277ef87b674ed9c35f9adc23a4206f";

        #region Functions
      
        public GetDeliverySingleResponse GetDeliverySingle(string id)
        {
            var client = new DeliveryClient(WumdropApiKey);

            return client.GetDeliverySingle(id);
        }

        public ListDeliveryResponse ListDeliveries()
        {
            var client = new DeliveryClient(WumdropApiKey);

            return client.ListDeliveries();
        }

        public CreateDeliveryResponse CreateDelivery()
        {
            var client = new DeliveryClient(WumdropApiKey);

            var rq = new CreateDeliveryRequest
            {
                pickup_address = "11 Adderley Street, Cape Town, South Africa",
                pickup_contact_name = "Hennie",
                pickup_contact_phone = "1231231235",
                pickup_remarks = "Hello World 1",
                dropoff_address = "5 Camps Bay Drive, Cape Town, South Africa",
                dropoff_contact_name = "Jake",
                dropoff_contact_phone = "1231321233",
                dropoff_remarks = "Hello Kitty 1"
            };


            return client.CreateDelivery(rq);

        }

        public MessageResponse CancelDelivery(string id)
        {
            var client = new DeliveryClient(WumdropApiKey);

            return client.CancelDelivery(id);
        }

        #endregion


        [SetUp]
        public void Setup()
        {
          
        }

        [Test]
        public void TestWumdropAuthentication()
        {
            var client = new DeliveryClient(WumdropApiKey);

            var response = client.AuthenticationTest();

            Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

        }

        [Test]
        public void CancelDelivery()
        {
            
            var createResponse = CreateDelivery();

            Assert.AreEqual(createResponse.HttpStatusCode, HttpStatusCode.OK);

            var response = CancelDelivery(createResponse.id);

            Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

        }

        [Test]
        public void TestListDeliveries()
        {
            
            var response = ListDeliveries();

            Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

        }

        [Test]
        public void GetDeliverySingle()
        {
            var createResponse = CreateDelivery();

            Assert.AreEqual(createResponse.HttpStatusCode, HttpStatusCode.OK);

            var response = GetDeliverySingle(createResponse.id);

            Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

            var cancelResponse = CancelDelivery(response.id);

            Assert.AreEqual(cancelResponse.HttpStatusCode, HttpStatusCode.OK);
        }


        [Test]
        public void TestCreateDelivery()
        {

            var response = CreateDelivery();

            Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

            //clean-up
            var cancelReponse = CancelDelivery(response.id);

            Assert.AreEqual(cancelReponse.HttpStatusCode, HttpStatusCode.OK);

        }

        [Test]
        public void EstimateTest()
        {
            var client = new EstimateClient(WumdropApiKey);

            var rq = new QuoteRequest()
            {
                lat1 = "-33.926401",
                lon1 = "18.444876",
                lat2 = "-33.926401",
                lon2 = "18.444876",
            };

            var response = client.GetQuote(rq);


            Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);
        }
    }
}