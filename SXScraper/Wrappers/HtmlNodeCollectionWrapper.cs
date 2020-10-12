using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace SXScraper
{
    public interface IPXHtmlNodeCollection
    {
        IPXHtmlNode First { get; }
        IEnumerable<IPXHtmlNode> All { get; }
    }

    public class HtmlNodeCollectionWrapper : IPXHtmlNodeCollection
    {
        //FIELDS
        private readonly HtmlNodeCollection collection;

        //PROPERTIES
        public IPXHtmlNode First => collection == null ? null : new HtmlNodeWrapper(collection.First());
        public IEnumerable<IPXHtmlNode> All
        {
            get
            {
                foreach (var node in collection)
                {
                    yield return new HtmlNodeWrapper(node);
                }
            }
        }


        //CONSTRUCTOR
        public HtmlNodeCollectionWrapper(HtmlNodeCollection collection)
        {
            this.collection = collection;
        }
    }


}
