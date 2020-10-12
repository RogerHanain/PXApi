using System.IO;

namespace SXFileManager.Document
{
    public interface IPXDocumentFactory
    {
        IPXDocument Create(string fullPath);
    }

    public class PXDocumentFactory : IPXDocumentFactory
    {
        public IPXDocument Create(string fullPath)
        {
            return new PXDocument(fullPath);
        }
    }
}
