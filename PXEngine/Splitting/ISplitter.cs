using System.Collections.Generic;

namespace DXProject.Splitting
{
    public interface ISplitter
    {
        IReadOnlyList<string> Process(string path, IProcessor processor);
    }
}