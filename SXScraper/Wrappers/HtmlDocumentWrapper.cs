using HtmlAgilityPack;
using System.Linq;

namespace SXScraper
{
    public interface IPXHtmlDocument
    {
        public IPXHtmlNode DocumentNode { get; }
    }

    public class HtmlDocumentWrapper : IPXHtmlDocument
    {
        public IPXHtmlNode DocumentNode => new HtmlNodeWrapper(htmlDocument.DocumentNode);

        private readonly HtmlDocument htmlDocument;

        public HtmlDocumentWrapper(HtmlDocument htmlDocument)
        {
            this.htmlDocument = htmlDocument;
        }
    }


}
