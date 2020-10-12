namespace SXFileManager.Document
{
    public interface IPXStreamWriterFactory
    {
        IPXStreamWriter Create(string path);
    }

    public class PXStreamWriterFactory : IPXStreamWriterFactory
    {
        public IPXStreamWriter Create(string path)
        {
            return new PXStreamWriter(path);
        }
    }
}