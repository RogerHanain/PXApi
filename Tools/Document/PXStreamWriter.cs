using System.IO;

namespace SXFileManager.Document
{
    public class PXStreamWriter : StreamWriter, IPXStreamWriter
    {
        internal PXStreamWriter(string path) : base(path)
        {
        }
    }
}