using HtmlAgilityPack;

namespace SXScraper
{
    public interface IHtmlWebWrapper
    {
        IPXHtmlDocument Load(string url);
    }

    public class HtmlWebWrapper : IHtmlWebWrapper
    {
        private readonly HtmlWeb htmlWeb;

        public HtmlWebWrapper(HtmlWeb htmlWeb)
        {
            this.htmlWeb = htmlWeb;
        }

        public IPXHtmlDocument Load(string url)
        {
            return new HtmlDocumentWrapper(htmlWeb.Load(url));
        }
    }
}
