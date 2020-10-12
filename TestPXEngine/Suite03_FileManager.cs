using IntegrationTests;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using SXFileManager.Document;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IntegrationTests
{
    public class Suite03_FileManager : BaseIntegrationTesting
    {
        public override bool UseDataFolder => true;

        [Test]
        public void Test001_InvalidMessageSinceItsADirectory()
        {
            //Arrange
            var data = this.DataFolder;

            //act & assert
            Assert.Throws(typeof(Exception), () => data.ReadAllText());
        }

        [Test]
        public void Test001b_InvalidMessageSinceItsADirectory()
        {
            //Arrange
            var data = this.DataFolder;

            //act & assert
            Assert.Throws(typeof(Exception), () => data.ReadAllLines());
        }

        [Test]
        public void Test002_InvalidMessageOnGetTypeSinceFileDoesntExist()
        {
            //Arrange
            var data = new PXDocument("dfhgfgsfhs.txt");

            //act & assert
            Assert.Throws(typeof(Exception), () => { var t = data.Type; });
        }

        [Test]
        public void Test003_RootIsReachedReturnsThrowsAnException()
        {
            //Arrange
            var data = DataFolder;

            //act & assert
            Assert.Throws(typeof(Exception), () => data.GetParent(10));
        }

        [Test]
        public void Test004_DocumentFactoryCreatesADocument()
        {
            //Arrange
            var f = new PXDocumentFactory();
            var data = f.Create(Path.Combine(DataFolder.Path, "test.txt"));

            //act & assert
            Assert.AreEqual("blabla1", data.ReadAllLines().First());
        }
    }
}
