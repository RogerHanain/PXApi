using System.Collections.Generic;

namespace DXProject.Splitting
{
    public interface IProcessor
    {
        IReadOnlyList<string> Process(string content, IContentFilter source);
    }

    /// <summary>
    /// Écrit dans un nouveau fichier le resultat du split et filter
    /// </summary>
    public class Processor : IProcessor
    {
        public const string RESULT_TERMINATION = "_result";

        public Processor()
        {
        }

        public IReadOnlyList<string> Process(string content, IContentFilter source)
        {
            var ws = new WordSplitter(content);

            var words = ws.Split();

            //return words;
            return source.Filter(words);
        }
    }
}
