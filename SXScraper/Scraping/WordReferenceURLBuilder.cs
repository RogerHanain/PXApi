namespace SXScraper
{
    public interface IWordReferenceURLBuilder
    {
        string Build(string word);
    }

    public class WordReferenceURLBuilder : IWordReferenceURLBuilder
    {
        public string Build(string word)
        {
            return @$"https://www.wordreference.com/enfr/{word}";
        }
    }
}
