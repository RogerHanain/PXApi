using PXApi.Models;
using System;
using System.Collections.Generic;

namespace PXWordReferenceScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var urlBread = @"https://www.wordreference.com/enfr/bread";

            //scraper le conteu
            var scraper = new Scraper();
            var translations = scraper.Scrape(urlBread);

            //l'ajouter à la base de données

        }
    }

    public class Scraper
    {
        public List<Translation> Scrape(string url)
        {
            var l = new List<Translation>();

            return l;
        }
    }
}
