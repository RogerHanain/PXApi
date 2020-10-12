using DXProject.Testing;
using Moq;
using NUnit.Framework;
using SXScraper;
using SXScraper.Scraping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class CaretAnalyserTests : BaseUnitTesting
    {
        CaretAnalyser caretAnalyser;

        protected override void Setup()
        {
            base.Setup();
            caretAnalyser = new CaretAnalyser(GetObject<IUseLessStringCleaner>());
        }


        [Test]
        public void ExtractTranslation_CleanerIsCalledWithTheInnertextOfTheFirstChildNode()
        {
            // Arrange
            var endNode = GetUnregisteredMock<IPXHtmlNode>();
            endNode.SetupGet(n => n.InnerText).Returns("blabla");

            var nodes = GetList<IPXHtmlNode>();
            GetMock<IPXHtmlNode>().SetupGet(n => n.ChildNodes.All).Returns(new List<IPXHtmlNode>() {endNode.Object });

            // Act
            var result = caretAnalyser.ExtractTranslation(nodes);

            // Assert
            GetMock<IUseLessStringCleaner>().Verify(c => c.Clean("blabla"),Times.Once());
        }
    }
}
