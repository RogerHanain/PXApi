using System.Collections.Generic;

namespace DXProject.Splitting
{
    public class Splitter : ISplitter
    {
        private readonly IContentFilter contentFilter;

        public Splitter(IContentFilter contentFilter)
        {
            this.contentFilter = contentFilter;
        }


        public IReadOnlyList<string> Process(string content, IProcessor processor)
        {
            var result = processor.Process(content, contentFilter);

            return result;
        }
    }
}
