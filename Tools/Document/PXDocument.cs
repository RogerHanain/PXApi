using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace SXFileManager.Document
{


    public enum PathType { File, Directory }

    /// <summary>
    /// Wrapper des classes Path et Directory de system.IO
    /// </summary>
    public class PXDocument : IPXDocument
    {
        //TODO séparer en deux sous classes et faire une factory
        const string THE_PATH_HAS_NO_FILE_OR_DIRECTORY = "The file/directory does not exist.";
        public PathType Type
        {
            get
            {
                if (Directory.Exists(Path)) return PathType.Directory;
                else if (File.Exists(Path)) return PathType.File;
                else throw new Exception(THE_PATH_HAS_NO_FILE_OR_DIRECTORY);
            }
        }

        public string Path { get; private set; }

        public PXDocument(string path)
        {
            this.Path = path;
        }

        public string GetParent(int count = 1)
        {
            var p = this.Path;

            for (int i = 0; i < count; i++)
            {
                if (Directory.GetDirectoryRoot(p) == p) throw new Exception("Impossible to return such a parent since the root is reached.");
                p = GetParent(p);
            }
            return p;
        }

        private string GetParent(string path)
        {
            return Directory.GetParent(path).FullName;
        }

        //TODO Faire une classe FileReader à part
        public List<string> ReadAllLines()
        {
            if (Type == PathType.File)
            {
                return File.ReadAllLines(Path).ToList();
            }
            throw new Exception(THE_PATH_HAS_NO_FILE_OR_DIRECTORY);
        }

        public string ReadAllText()
        {
            if (Type == PathType.File)
            {
                return File.ReadAllText(Path);
            }
            throw new Exception(THE_PATH_HAS_NO_FILE_OR_DIRECTORY);
        }

        //Clear the content of the file or empties the directory
        public void Clear()
        {
            if (Type == PathType.File)
            {
                File.WriteAllText(this.Path, "");
            }
            else if (Type == PathType.Directory)
            {
                foreach (var item in Directory.EnumerateFiles(this.Path))
                {
                    File.Delete(item);
                }
            }
        }
    }
}
