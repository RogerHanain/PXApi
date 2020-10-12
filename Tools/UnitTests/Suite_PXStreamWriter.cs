using DXProject.Testing;
using Moq;
using NUnit.Framework;
using SXFileManager.Document;
using System.IO;

namespace UnitTests
{
    [TestFixture]
    public class PXStreamWriterTests : BaseUnitTesting
    {
        PXStreamWriter pXStreamWriter;

        protected override void Setup()
        {
            base.Setup();
            pXStreamWriter = new PXStreamWriter("fdgsdfg");
        }


        [Test]
        public void Ctor_PXStreamWriterIsAWrapperOnStreamWriter()
        {
            // Act
            Assert.IsTrue(pXStreamWriter is StreamWriter);
        }
    }
}
