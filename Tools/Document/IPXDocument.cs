using System.Collections.Generic;

namespace SXFileManager.Document
{
    public interface IPXDocument
    {
        string Path { get; }
        PathType Type { get; }

        void Clear();
        List<string> ReadAllLines();
        string GetParent(int count = 1);
        string ReadAllText();
    }
}