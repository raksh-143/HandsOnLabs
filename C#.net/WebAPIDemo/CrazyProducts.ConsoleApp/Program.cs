using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrazyProducts.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get only specific information from the JSON file
            string baseUrl = "https://localhost:44358/api/crazyproducts";
            HttpClient client = new HttpClient();
            //To suppress certificate related errors
            ServicePointManager.ServerCertificateValidationCallback +=  (sender, cert, chain, sslPolicyErrors) => true;
            string product = client.GetStringAsync(baseUrl).GetAwaiter().GetResult();
            Console.WriteLine(product);
            var responseMessage = client.GetAsync(baseUrl).Result;
            if(responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = responseMessage.Content;
                var productList = content.ReadAsAsync<List<Product>>().Result;
                foreach(var item in productList)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
