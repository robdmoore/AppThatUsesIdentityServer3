using System;
using System.Net.Http;
using IdentityModel.Client;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = GetClientToken();
            if (token.IsError)
            {
                Console.WriteLine(token.HttpErrorStatusCode);
            }
            else
            {
                Console.WriteLine(token.Raw);
                CallApi(token);
            }
            Console.ReadLine();
        }

        static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://appwithformsauth.localtest.me/identity/connect/token",
                "reporting",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("reporting_api").Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            var r = client.GetAsync("http://anotherapp.localtest.me/test").Result;

            Console.WriteLine(r.StatusCode);
            Console.WriteLine(r.Content.ReadAsStringAsync().Result);
        }
    }
}
