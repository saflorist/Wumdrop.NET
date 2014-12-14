## Wumdrop.NET
===========

A simple .NET client for integrating with Wumdrop's delivery API.

### API Authentication (for unit testing purposes only)

```c#

	var client = new DeliveryClient(WumdropApiKey);

	var response = client.AuthenticationTest();

    Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

```

### Creating a delivery

```c#

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
	
	var response = client.CreateDelivery(rq);
	
	Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

```

### Cancelling a delivery

```c#

	var client = new DeliveryClient(WumdropApiKey);

	var response = client.CancelDelivery(deliveryId);
	
	Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

```

### Listing all deliveries

```c#
	
	var client = new DeliveryClient(WumdropApiKey);

	var response = client.ListDeliveries();
	
	foreach (var delivery in response.deliveries)
	{
		Console.Write(delivery.state);
	}
	
	Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

```

### Retrieving a single delivery

```c#

	var client = new DeliveryClient(WumdropApiKey);

	var response = client.GetDeliverySingle(id);
	
	Assert.AreEqual(response.HttpStatusCode, HttpStatusCode.OK);

```

### Retrieving a quote

```c#

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

```


