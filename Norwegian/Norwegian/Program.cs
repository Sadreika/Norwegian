﻿using System;

namespace Norwegian
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();
            crawler.crawling();
            Console.ReadLine();
        }
    }
}
