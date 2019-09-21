using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HttpClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = new List<HttpClient>();

            for (var i = 0; i < 1000; i++)
            {
                var httpClientHandler = new HttpClientHandler();
                var httpClient = new HttpClient(httpClientHandler, false);

                var resp = httpClient.GetAsync("http://www.baidu.com")
                    .GetAwaiter()
                    .GetResult();

                clients.Add(httpClient);

                Console.WriteLine($"{httpClient} requested {i}");
            }




            Console.ReadKey();
        }
    }
}
