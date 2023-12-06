
using PayCore.Client.models;
using RestSharp;

RestClient client = new RestClient("https://localhost:7185/api/");

RestRequest request = new RestRequest("Product", Method.Get);


var response = client.Execute<List<Product>>(request);


foreach (var item in response.Data)
{
    Console.WriteLine(item.Name);
}

Console.ReadLine();









