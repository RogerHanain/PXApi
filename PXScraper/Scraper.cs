using HtmlAgilityPack;
using PXApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PXScraper
{
    //TODO créer un IhtmlNodeProvider et un IHTMLNode dans Tools et injecter
    public class Scraper
    {
        public Scraper(IDatabaseFeeder feeder)
        {
            Feeder = feeder;
        }

        public IDatabaseFeeder Feeder { get; }

        public void Scrape(IScrapeTarget target)
        {
            var l = new List<ITranslation>();
            var bread = new Translation();

            var web = new HtmlAgilityPack.HtmlWeb();
            var doc = web.Load(target.URL);

            //Get the big node for principal
            var principalTranslations = GetNodes("table", "WRD", doc.DocumentNode).First();
            var allEvens = GetNodes("tr", "even", principalTranslations);

            var breadNodes = GetFirstTranslation(allEvens);
            var translation = GetTranslation(breadNodes);
            l.Add(translation);
            Feeder.Feed(l);
        }

        private HtmlNodeCollection GetNodes(string classType, string className, HtmlNode documentNode)
        {
            return documentNode.SelectNodes($"//{classType}[@class='{className}']");
        }

        private List<HtmlNode> GetFirstTranslation(HtmlNodeCollection evens)
        {
            var res = new List<HtmlNode>();

            int count = 0;

            foreach (var item in evens)
            {
                if (item.Id != "") count++;
                if (count > 1) return res;

                res.Add(item);
            }
            return res;
        }

        private ITranslation GetTranslation(List<HtmlNode> nodes)
        {
            var translation = new Translation();

            //Get Name
            var childrenFirstLine = nodes.First().ChildNodes.ToList();
            translation.Word = CleanEnglishName(childrenFirstLine[0].InnerText);

            //Get English Details
            translation.EnglishDetails = CleanEnglishDetails(childrenFirstLine[1].InnerText);

            //Get french
            translation.FrenchTranslations = CleanFrenchTranslation(childrenFirstLine[2].InnerText);

            //Get Example
            var firstSentence = nodes[2].ChildNodes.ToList()[1].InnerText.Trim();
            var secondSentence = nodes[3].ChildNodes.ToList()[1].InnerText.Trim();
            translation.Example = $"{firstSentence} {secondSentence}";

            return translation;
        }

        private string CleanEnglishName(string nodeInnerText)
        {
            const string noun = " nnoun: Refers to person, place, thing, quality, etc.";
            return nodeInnerText.Replace(noun, "");
        }

        private string CleanFrenchTranslation(string nodeInnerText)
        {
            var l = new List<string>();
            l.Add(" nmnom masculin: s'utilise avec les articles \"le\", \"l'\" (devant une voyelle ou un h muet), \"un\". Ex : garçon - nm > On dira \"le garçon\" ou \"un garçon\". ");
            l.Add(" nfnom féminin: s'utilise avec les articles \"la\", \"l'\" (devant une voyelle ou un h muet), \"une\". Ex : fille - nf > On dira \"la fille\" ou \"une fille\". Avec un nom féminin, l'adjectif s'accorde. En général, on ajoute un \"e\" à l'adjectif. Par exemple, on dira \"une petite fille\".");
            string s = nodeInnerText;
            foreach (var item in l)
            {
                if (!s.Contains(item)) continue;
                s = nodeInnerText.Replace(item, "");
            }
            return s;
        }

        private string CleanEnglishDetails(string nodeInnerText)
        {
            if (nodeInnerText.Contains("&nbsp"))
            {
                return nodeInnerText.Split("&nbsp").First().Trim();
            }
            return nodeInnerText.Trim();
        }
    }

    public interface IScrapeTarget
    {
        public string URL { get; set; }
    }

    public interface IDatabaseFeeder
    {
        public void Feed(IEnumerable<ITranslation> translations);
    }
}
