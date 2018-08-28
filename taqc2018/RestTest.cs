using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NLog;
using RestSharp;
using System.Runtime.Serialization;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace taqc2018
{
    [TestFixture]
    public class RestTest
    {
        public Logger log = LogManager.GetCurrentClassLogger(); // for NLog

        //[Test]
        public void VerifyItems()
        {
            log.Info("Start");
            string url = "http://localhost:8080/";
            var client = new RestClient(url);
            var request = new RestRequest("/items", Method.GET);
            request.AddParameter("token", "O4W7NGT4UNY6R6JN1T82O9N6M7IMEDI2");
            // Execute Request
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("content: " + content);
            Assert.True(content.Contains("Hello World"));
            log.Info("content: " + content);
        }

        //[Test]
        public void VerifyLogin()
        {
            log.Info("Start");
            string url = "http://localhost:8080/";
            var client = new RestClient(url);
            var request = new RestRequest("/login", Method.POST);
            //
            //request.AddParameter("login", "admin", ParameterType.RequestBody);
            //request.AddParameter("password", "qwerty", ParameterType.RequestBody);
            //request.AddQueryParameter("login", "admin");
            //request.AddQueryParameter("password", "qwerty");
            //
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW",
                "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"name\"\r\n\r\nadmin\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"password\"\r\n\r\nqwerty\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--",
                ParameterType.RequestBody);
            //
            // Execute Request
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine("content: " + content);
            string token = content.Substring(content.IndexOf(":\"") + 2);
            token = token.Substring(0, token.Length - 2);
            Console.WriteLine("token: " + token + " Length= " + content.Length);
            Assert.True(content.Length == 46);
            log.Info("token= " + token);
        }

        //[Test]
        public void ReadData1()
        {
            log.Info("Start");
            //
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //
            string url = "https://api.github.com/orgs/dotnet/repos";
            //string url = "https://api.github.com";
            var client = new RestClient(url);
            //var request = new RestRequest("/orgs/dotnet/repos", Method.GET);
            var request = new RestRequest(Method.GET);
            //
            request.AddHeader("Postman-Token", "b69e2907-9b7f-48d9-864d-728250f852bd");
            request.AddHeader("Cache-Control", "no-cache");
            //
            // Execute Request
            IRestResponse response = client.Execute(request);
            Console.WriteLine("IsSuccessful: " + response.IsSuccessful);
            var content = response.Content;
            Console.WriteLine("content: " + content);
            //Assert.True(content.Length == 46);
            log.Info("done ");
        }

        //[Test]
        public void ReadData2()
        {
            log.Info("Start");
            //
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //
            string url = "https://api.github.com/orgs/dotnet/repos";
            // Create WebClient
            using (var webClient = new WebClient())
            {
                webClient.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                    "(compatible; MSIE 6.0; Windows NT 5.1; " +
                    ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                //
                // get response
                var response = webClient.DownloadString(url);
                Console.WriteLine(response);
            }
            log.Info("done ");
        }

    }
}
