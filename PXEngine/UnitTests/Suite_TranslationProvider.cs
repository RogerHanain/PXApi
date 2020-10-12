using DXProject.Database;
using DXProject.Scraping;
using DXProject.Testing;
using Moq;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class Suite_TranslationProvider : BaseUnitTesting
    {
        TranslationProvider provider;

        protected override void Setup()
        {
            base.Setup();
            provider = new TranslationProvider(GetObject<ITranslationScraper>());
        }


        [Test]
        public void GetTranslations_MakesACallOnTheScraperWithTheWord()
        {
            // Arrange
            string word = "blabla";


            // Act
            var result = provider.GetTranslations(word);

            // Assert
            GetMock<ITranslationScraper>().Verify(s => s.Scrape(word), Times.Once());
        }
    }
}
