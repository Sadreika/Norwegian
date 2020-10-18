using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace Norwegian
{
    public class Crawler
    {
        //private IList<RestResponseCookie> cookieList = new List<RestResponseCookie>();


        public string departureAirport;
        public string arrivalAiport;
        public string departureTime;
        public string arrivalTime;
        public string cheapestPrice;
        public List<Crawler> allCollectedData = new List<Crawler>();
        
        public Crawler()
        {

        }

        public Crawler(string departureAirport, string arrivalAiport, string departureTime, string arrivalTime, string cheapestPrice)
        {
            this.departureAirport = departureAirport;
            this.arrivalAiport = arrivalAiport;
            this.departureTime = departureTime;
            this.arrivalTime = arrivalTime;
            this.cheapestPrice = cheapestPrice;
        }

        public void crawling()
        {
            //firstPageLoad();
            HtmlDocument doc = new HtmlDocument();
            readingTxtFile(doc);
            gettingData(doc);
        }

        private HtmlDocument readingTxtFile(HtmlDocument doc)
        {
            string text = File.ReadAllText("Norwegian code.txt");
            doc.LoadHtml(text);
            return doc;
        }
        private void gettingData(HtmlDocument htmlDocument)
        {
            List<String> departureAirports = new List<string>();
            List<String> arrivalAirports = new List<string>();
            List<String> departureTime = new List<string>();
            List<String> arrivalTime = new List<string>();
            List<String> cheapestPrice = new List<string>();
          
            foreach (HtmlNode data in htmlDocument.DocumentNode.SelectNodes("//td[@class='depdest']//div[@class='content']"))
            {
                departureAirports.Add(data.InnerText);
            }
            foreach (HtmlNode data in htmlDocument.DocumentNode.SelectNodes("//td[@class='arrdest']//div[@class='content']"))
            {
                arrivalAirports.Add(data.InnerText);
            } 
            foreach (HtmlNode data in htmlDocument.DocumentNode.SelectNodes("//td[@class='depdest']//div[@class='content emphasize']"))
            {
                departureTime.Add(data.InnerText);
            }
            foreach (HtmlNode data in htmlDocument.DocumentNode.SelectNodes("//td[@class='arrdest']//div[@class='content emphasize']"))
            {
                arrivalTime.Add(data.InnerText);
            }
            foreach (HtmlNode data in htmlDocument.DocumentNode.SelectNodes("//td[@class='fareselect standardlowfare']//div[@class='content']"))
            {
                cheapestPrice.Add(data.InnerText);
            }

            for(int i = 0; i < cheapestPrice.Count; i++)
            {
                Crawler crawler = new Crawler(departureAirports[i], arrivalAirports[i], departureTime[i], arrivalTime[i], cheapestPrice[i]);
                allCollectedData.Add(crawler);
            }
        }

        //JUNK
        private  void firstPageLoad()
        {
            RestClient client = new RestClient("https://www.norwegian.com/uk");
            client.AddDefaultHeader("Host", "www.norwegian.com");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:81.0) Gecko/20100101 Firefox/81.0";
            client.AddDefaultHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            client.AddDefaultHeader("Accept-Language", "en-GB,en;q=0.5");
            client.AddDefaultHeader("Accept-Encoding", "gzip, deflate, br");
            client.AddDefaultHeader("DNT", "1");
            client.ConnectionGroupName = "keep-alive";
            client.AddDefaultHeader("Upgrade-Insecure-Requests", "1");
           
            RestRequest request = new RestRequest("", Method.GET);
            
            IRestResponse response = client.Execute(request);
            addingCookiesToCookieList(response.Cookies);
        }
        public void addingCookiesToCookieList(IList<RestResponseCookie> cookiesToAdd)
        {
            foreach (RestResponseCookie cookie in cookiesToAdd)
            {
               // cookieList.Add(cookie);
            }
        }
        
    }
}
