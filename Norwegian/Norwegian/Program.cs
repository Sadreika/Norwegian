﻿using System;

namespace Norwegian
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            crawler.crawlingAsync().Wait();
            Console.ReadLine();
        }
    }
}
