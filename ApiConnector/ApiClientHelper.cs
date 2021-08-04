using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Assignment1
{
    static class ApiClientHelper
    {
        public static HttpClient ApiClient { get; private set; }
        public static string RapidApiKey { get; private set; } = "d38d73d424msh39e37145a05b762p1aa05fjsnae1b946853fa";

        static ApiClientHelper()
        {
            //Console.WriteLine("Client connected");
            InitializeClient();
        }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
