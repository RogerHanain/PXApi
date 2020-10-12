using SXFileManager.Document;
using System.Collections.Generic;

namespace SXFileManager.Document
{


    /// <summary>
    /// Ecrit une liste de ligne dans un fichier
    /// </summary>
    public class FileWriter : IFileWriter
    {
        private IPXStreamWriterFactory streamWriterFactory;

        public FileWriter(IPXStreamWriterFactory streamWriterFactory)
        {
            this.streamWriterFactory = streamWriterFactory;
        }

        /// <summary>
        ///If the file exists it will be overwritten, otherwise a file is created
        /// </summary>
        public void Write(string path, IEnumerable<string> content)
        {
            using (var sw = streamWriterFactory.Create(path))
            {
                foreach (var line in content)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}