using DXProject.Testing;
using Moq;
using NUnit.Framework;
using SXFileManager.Document;
using System;

namespace UnitTests
{
    [TestFixture]
    public class Suite_PXDocumentFactory : BaseUnitTesting
    {
        PXDocumentFactory factory;

        protected override void Setup()
        {
            base.Setup();
            factory = new PXDocumentFactory();
        }


        [Test]
        public void Create_ReturnsANewPXDocument()
        {
            // Arrange
            string fullPath = "";

            // Act
            var result = factory.Create(fullPath);

            // Assert
            Assert.IsTrue(result is IPXDocument);
        }
    }
}
