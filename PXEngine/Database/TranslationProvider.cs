using DXProject.Models;
using DXProject.Scraping;
using System.Collections.Generic;

namespace DXProject.Database
{
    public class TranslationProvider
    {
        private readonly ITranslationScraper scraper;

        public TranslationProvider(ITranslationScraper scraper)
        {
            this.scraper = scraper;
        }

        public IReadOnlyList<ITranslation> GetTranslations(string word)
        {
            var translations = new List<ITranslation>();

            translations.AddRange(scraper.Scrape(word));

            return translations;
        }
    }
}
