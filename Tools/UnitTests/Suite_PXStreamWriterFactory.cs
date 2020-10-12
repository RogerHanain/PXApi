using DXProject.Testing;
using Moq;
using NUnit.Framework;
using SXFileManager.Document;
using System;

namespace UnitTests
{
    [TestFixture]
    public class Suite_PXStreamWriterFactory : BaseUnitTesting
    {
        PXStreamWriterFactory factory;

        protected override void Setup()
        {
            base.Setup();
            factory = new PXStreamWriterFactory();
        }


        [Test]
        public void Create_ResultIsAIPXStreamWriter()
        {
            string path = "sdfhsgfh";
            
            // Act
            var result = factory.Create(path);

            // Assert
            Assert.IsTrue(result is IPXStreamWriter);
        }
    }
}
