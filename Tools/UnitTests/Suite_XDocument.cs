using NUnit.Framework;
using SXFileManager.Document;
using System;
using System.IO;

namespace UnitTests
{
    class Suite_XDocument
    {
        [Test]
        public void Test001_GetType_VerifyCurrentFolderIsaDirectory()
        {
            //Arrange
            var p = Directory.GetCurrentDirectory();

            //Act
            var type = new PXDocument(p).Type;

            //Assert
            Assert.AreEqual(PathType.Directory, type);
        }

        [Test]
        public void Test002a_GetParent_VerifiyCountTwo()
        {
            var p = new PXDocument(@"C:\SIMULATIONS\CMG\328FT\Asdsfg");
            Assert.AreEqual(@"C:\SIMULATIONS\CMG", p.GetParent(2));
        }

        [Test]
        public void Test02b_GetParent_TooMuchCountThrowsAnException()
        {
            var p = new PXDocument(@"C:\SIMULATIONS\CMG\328FT\Asdsfg");
            Assert.Throws(typeof(Exception), () => p.GetParent(10));
        }

        [Test]
        public void Test003a_GetContent_ThrowsAnExceptionIfFileDoesntExist()
        {
            var path = "dfgdfg.txt";

            var p = new PXDocument(path);

            Assert.Throws(typeof(Exception), () => p.ReadAllLines());
        }
    }
}
