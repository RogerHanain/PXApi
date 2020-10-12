using DXProject.Models;
using DXProject.Scraping;
using HtmlAgilityPack;
using SXScraper.Scraping;
using System.Collections.Generic;
using System.Linq;

namespace SXScraper
{
    public class WordReferenceScraper : ITranslationScraper
    {
        //FIELDS
        private readonly IHtmlDocumentFactory htmlDocumentFactory;
        private readonly IWordReferenceURLBuilder wordReferenceURLBuilder;
        private readonly ICaretAnalyser caretAnalyser;
        
        private IPXHtmlDocument htmlDocument;
        private string word;
        private IPXHtmlNodeCollection firstCaretCollection;
        private List<IPXHtmlNode> firstLineNodes;
        private ITranslation translation;

        //CONSTRUCTOR
        public WordReferenceScraper(IHtmlDocumentFactory htmlDocumentFactory, IWordReferenceURLBuilder urlBuilder, ICaretAnalyser caretAnalyser)
        {
            this.htmlDocumentFactory = htmlDocumentFactory;
            
            this.wordReferenceURLBuilder = urlBuilder;

            this.caretAnalyser = caretAnalyser;
        }

        //METHODS
        public List<ITranslation> Scrape(string word)
        {
            this.word = word;

            InitializeHtmlDocument();

            SetFirstCaretCollection();

            if (firstCaretCollection == null) return new List<ITranslation>();

            SetFirstLineFromFirstCaret();

            SetTranslationWithCaretAnalyser();

            return new List<ITranslation>() { translation };
        }

        private void SetTranslationWithCaretAnalyser()
        {
            translation = caretAnalyser.ExtractTranslation(firstLineNodes);
        }

        private void SetFirstCaretCollection()
        {
            var principalTranslations = htmlDocument.DocumentNode?.SelectNodes($"//table[@class='WRD']");

            firstCaretCollection = principalTranslations?.First?.SelectNodes($"//tr[@class='even']");
        }

        private void InitializeHtmlDocument()
        {
            string url = wordReferenceURLBuilder.Build(word);

            htmlDocument = htmlDocumentFactory.CreateHtmlDocument(url);
        }

        private void SetFirstLineFromFirstCaret()
        {
            int count = 0;

            firstLineNodes = new List<IPXHtmlNode>();

            firstLineNodes.Clear();

            foreach (var item in firstCaretCollection.All)
            {
                if (item.Id != "") count++;
                if (count > 1) return;

                firstLineNodes.Add(item);
            }
        }
    }
}
