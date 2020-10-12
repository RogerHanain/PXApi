using DXProject.Testing;
using Moq;
using NUnit.Framework;
using SXScraper;
using SXScraper.Scraping;
using System;

namespace UnitTests
{
    [TestFixture]
    public class WordReferenceScraperTests : BaseUnitTesting
    {
        WordReferenceScraper wordReferenceScraper;

        protected override void Setup()
        {
            base.Setup();
            wordReferenceScraper = new WordReferenceScraper(
                GetObject<IHtmlDocumentFactory>(),
                GetObject<IWordReferenceURLBuilder>(),
                GetObject<ICaretAnalyser>());
        }


        [TestCase("blabla")]
        [TestCase("qgsfh")]
        public void Scrape_UrlBuilderIsCreatedWithTheWord(string word)
        {
            // Arrange

            // Act
            var result = wordReferenceScraper.Scrape(word);

            // Assert
            GetMock<IWordReferenceURLBuilder>().Verify(b => b.Build(word), Times.Once());
        }
    }
}
