using DXProject.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SXScraper.Scraping
{
    public interface ICaretAnalyser
    {
        ITranslation ExtractTranslation(List<IPXHtmlNode> nodes);
    }

    public class CaretAnalyser : ICaretAnalyser
    {
        private List<IPXHtmlNode> nodes;
        private Translation translation;
        private readonly IUseLessStringCleaner useLessStringCleaner;

        public CaretAnalyser(IUseLessStringCleaner useLessStringCleaner)
        {
            this.useLessStringCleaner = useLessStringCleaner;
        }

        public ITranslation ExtractTranslation(List<IPXHtmlNode> nodes)
        {
            translation = new Translation();

            this.nodes = nodes;

            SetWordNameInTranslation();

            TrySetEnglishDetails();

            TrySetFrenchTranslation();

            SetExampleInTranslation();

            return translation;
        }

        private void SetWordNameInTranslation()
        {
            var nodeInnerText = nodes.First().ChildNodes.All.First().InnerText;

            var s = useLessStringCleaner.Clean(nodeInnerText);

            if (nodeInnerText.Contains(", also UK"))
            {
                s = s.Split(", also UK")[0];
            }

            translation.Word = s;
        }

        private void SetExampleInTranslation()
        {
            string firstSentence = "";
            string secondSentence = "";
            if (nodes.Count == 1)
            {
                translation.Example = "";
                return;
            }
            if (nodes.Count == 2)
            {
                firstSentence = nodes[1].ChildNodes.All.ToList()[1].InnerText.Trim();
            }
            else if (nodes.Count == 3)
            {
                firstSentence = nodes[1].ChildNodes.All.ToList()[1].InnerText.Trim();
                secondSentence = nodes[2].ChildNodes.All.ToList()[1].InnerText.Trim();
            }
            else
            {
                firstSentence = nodes[2].ChildNodes.All.ToList()[1].InnerText.Trim();
                secondSentence = nodes[3].ChildNodes.All.ToList()[1].InnerText.Trim();
            }
            translation.Example = $"{firstSentence} {secondSentence}";
        }


        private void TrySetFrenchTranslation()
        {
            var childNodes = nodes.First().ChildNodes.All.ToList();

            if (childNodes.Count < 3) return;

            var nodeInnerText = childNodes[2].InnerText;

            translation.FrenchTranslations = useLessStringCleaner.Clean(nodeInnerText); ;
        }

        private void TrySetEnglishDetails()
        {
            var childNodes = nodes.First().ChildNodes.All.ToList();

            if (childNodes.Count < 2) return;

            var nodeInnerText = childNodes[1].InnerText;
            if (nodeInnerText.Contains("&nbsp"))
            {
                translation.EnglishDetails = nodeInnerText.Split("&nbsp").First().Trim();
                return;
            }
            translation.EnglishDetails = nodeInnerText.Trim();
        }

    }
}
