using System;
using System.Net;
using System.Net.Http;

namespace Norwegian
{
    public class Crawler
    {
        private string url = "https://www.norwegian.com/uk/";

        public void crawling()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Host = "www.norwegian.com";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:81.0) Gecko/20100101 Firefox/81.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Headers.Add("Accept-Language", "lt,en-US;q=0.8,en;q=0.6,ru;q=0.4,pl;q=0.2");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("DNT", "1");
            request.KeepAlive = true;
            request.Headers.Add("Upgrade-Insecure-Requests", "1");

            var response = (HttpWebResponse)(request.GetResponse());
            Console.WriteLine(response.StatusCode);

        }
    }
}
