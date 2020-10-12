using DXProject.Testing;
using NUnit.Framework;
using SXFileManager.Document;
using System;
using System.IO;

namespace IntegrationTests
{
    public class BaseIntegrationTesting : BaseUnitTesting
    {
        protected PXDocument DataFolder => UseDataFolder ? dataFolder : throw new Exception("Override UseDataFolder to use it.");
        private PXDocument dataFolder;

        protected PXDocument TmpFolder => UseTmpFolder ? tmpFolder : throw new Exception("Override UseTmpFolder to use it.");
        private PXDocument tmpFolder;

        private const string DATA_FOLDER_NAME = "Data";
        private const string TMP_FOLDER_NAME = "Tmp";

        public virtual bool UseTmpFolder => false;
        public virtual bool UseDataFolder => false;

        protected override void Setup()
        {
            base.Setup();

            if (UseTmpFolder)
            {
                if (!Directory.Exists(TmpFolder.Path))
                {
                    Directory.CreateDirectory(tmpFolder.Path);
                }
                else TmpFolder.Clear();
            }
        }

        public BaseIntegrationTesting()
        {
            if (!UseTmpFolder && !UseDataFolder) return;

            //Directory.GetCurrentDirectory() m'envoie dans l'AppData/Local/Temp
            var executingAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var p = new PXDocument(Path.GetDirectoryName(executingAssemblyPath));

            if (UseTmpFolder) tmpFolder = new PXDocument(Path.Combine(p.GetParent(3), DATA_FOLDER_NAME, TMP_FOLDER_NAME));
            if (UseDataFolder) dataFolder = new PXDocument(Path.Combine(p.GetParent(3), DATA_FOLDER_NAME));
        }

        public string TmpFile(string fileName)
        {
            return Path.Combine(TmpFolder.Path, fileName);
        }

        public string DataFile(string fileName)
        {
            return Path.Combine(DataFolder.Path, fileName);
        }
    }
}
