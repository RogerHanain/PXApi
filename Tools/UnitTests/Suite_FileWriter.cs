using DXProject.Testing;
using Moq;
using NUnit.Framework;
using SXFileManager.Document;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class Suite_FileWriter : BaseUnitTesting
    {
        FileWriter fileWriter;

        protected override void SetFactories()
        {
            base.SetFactories();
            GetMock<IPXStreamWriterFactory>().Setup(f => f.Create(GetAny<string>())).Returns(GetObject<IPXStreamWriter>());
        }

        protected override void Setup()
        {
            base.Setup();
            fileWriter = new FileWriter(GetObject<IPXStreamWriterFactory>());
        }


        [Test]
        public void Write_WriterFactoryIsCalledOnceToCreateAWriter()
        {
            // Arrange
            var path = "";
            var content = new List<string>();

            // Act
            fileWriter.Write(path, content);

            // Assert
            GetMock<IPXStreamWriterFactory>().Verify(f => f.Create(path), Times.Once());
        }

        [Test]
        public void Write_WriteLineIsCalledOnEachline()
        {
            // Arrange
            var path = "";
            var content = new List<string>();
            content.Add("blabla");
            content.Add("bloblo");

            // Act
            fileWriter.Write(path, content);

            // Assert
            GetMock<IPXStreamWriter>().Verify(w => w.WriteLine(GetAny<string>()), Times.Exactly(2));
        }
    }
}
