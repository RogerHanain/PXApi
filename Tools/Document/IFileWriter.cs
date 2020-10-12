using System.Collections.Generic;

namespace SXFileManager.Document
{
    public interface IFileWriter
    {
        void Write(string path, IEnumerable<string> content);
    }
}