using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SXScraper
{
    public interface IHtmlDocumentFactory
    {
        IPXHtmlDocument CreateHtmlDocument(string url);
    }

    public class HtmlDocumentFactory : IHtmlDocumentFactory
    {
        public HtmlDocumentFactory()
        {
        }

        public IPXHtmlDocument CreateHtmlDocument(string url)
        {
            var web = new HtmlAgilityPack.HtmlWeb();

            var webWrapper = new HtmlWebWrapper(web);

            return webWrapper.Load(url);
        }
    }
}
