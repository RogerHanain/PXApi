using DXProject.Models;
using System.Collections.Generic;

namespace DXProject.Scraping
{
    public interface ITranslationScraper
    {
        List<ITranslation> Scrape(string word);
    }
}
