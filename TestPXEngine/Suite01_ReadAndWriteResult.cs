using DXProject.Splitting;
using Moq;
using NUnit.Framework;
using SXFileManager;
using SXFileManager.Document;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntegrationTests
{
    public class Suite01_ReadAndWriteResult : BaseIntegrationTesting
    {
        private Splitter project;
        private ContentFilter contentFilter;

        public override bool UseTmpFolder => true;
        public override bool UseDataFolder => true;

        protected override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void Test001_Write_CheckAFileIsWrittenAndClearIt()
        {
            var l = new List<string>() { "blabla", "chiasse" };
            var fileWriter = new FileWriter(new PXStreamWriterFactory());
            var testDoc = new PXDocument(TmpFile("test.txt"));

            //Write
            fileWriter.Write(testDoc.Path, l);
            Assert.AreEqual(PathType.File, testDoc.Type);
            Assert.AreEqual(l, File.ReadAllLines(testDoc.Path));
            Assert.AreEqual("blabla\r\nchiasse\r\n", testDoc.ReadAllText());

            //Clear
            testDoc.Clear();
            Assert.AreEqual("", File.ReadAllLines(testDoc.Path));
        }

        [Test]
        public void Test002_CheckContentInTestFile()
        {
            var path = DataFile("test.txt");

            var p = new PXDocument(path);

            Assert.AreEqual(new List<string>() { "blabla1", "blabla2" }, p.ReadAllLines());
        }

        [Test]
        public void Test003_CheckWordsDontAppearTwice()
        {
            //dictionary
            contentFilter = new ContentFilter();

            //create project
            project = new Splitter(contentFilter);

            //process sentence le path est bypassé de toute facon
            var r = project.Process("my tailor is my tailor.", new Processor());

            Assert.AreEqual(new List<string>() { "my", "tailor", "is" }, r);
        }

        [Test]
        public void Test004_CheckDuplicatesOnFriends()
        {
            contentFilter = new ContentFilter();

            var friendss05e14 = new PXDocument(DataFile("FRIENDS_05x14.srt"));
            var testDoc = new PXDocument(TmpFile("FRIENDS_05x14_result.txt"));

            project = new Splitter(contentFilter);

            var r = project.Process(friendss05e14.ReadAllText(), new Processor());

            Assert.AreEqual(1, r.Where(i => i == "you").Count());
        }
    }
}
