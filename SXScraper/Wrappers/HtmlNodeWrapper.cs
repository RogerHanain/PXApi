using HtmlAgilityPack;

namespace SXScraper
{
    public interface IPXHtmlNode
    {
        string Id { get; }
        IPXHtmlNodeCollection ChildNodes { get; }
        string InnerText { get; }

        IPXHtmlNodeCollection SelectNodes(string xpath);
    }

    public class HtmlNodeWrapper : IPXHtmlNode
    {
        private readonly HtmlNode node;

        public string Id => node.Id;
        public string InnerText => node.InnerText;
        public IPXHtmlNodeCollection ChildNodes => new HtmlNodeCollectionWrapper(node.ChildNodes);

        public HtmlNodeWrapper(HtmlNode node)
        {
            this.node = node;
        }

        public IPXHtmlNodeCollection SelectNodes(string xpath)
        {
            return new HtmlNodeCollectionWrapper(node.SelectNodes(xpath));
        }
    }


}
