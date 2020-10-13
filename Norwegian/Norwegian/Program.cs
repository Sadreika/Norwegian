namespace Norwegian
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            //Proxy proxy = new Proxy();
            //List<Proxy> proxyAddressList = new List<Proxy>();
            //proxyAddressList = proxy.hidemyProxy();
            //foreach(Proxy prox in proxyAddressList)
            {
                crawler.crawling(/*prox*/);
            }
        }
    }
}
