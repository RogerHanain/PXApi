using Moq;
using NUnit.Framework;
using PXApi.Models;
using PXTools.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PXScraper.ZZTests
{
    public class Suite_Scraper : BaseUnitTesting
    {
        private Scraper scraper;

        protected override void Setup()
        {
            base.Setup();

            scraper = new Scraper(GetObject<IDatabaseFeeder>());
        }

        [Test]
        public void Test001_FeederIsCreated()
        {
            Assert.AreEqual(GetObject<IDatabaseFeeder>(), scraper.Feeder);
        }

        [Test]
        public void Test002_FeederIsCalledOnce()
        {
            //Arrange
            var url = @"https://www.wordreference.com/enfr/bread";
            GetMock<IScrapeTarget>().SetupGet(t => t.URL).Returns(url);

            //Act
            scraper.Scrape(GetObject<IScrapeTarget>());

            //Assert
            GetMock<IDatabaseFeeder>().Verify(f => f.Feed(It.IsAny<IEnumerable<ITranslation>>()), Times.Once());
        }

        [TestCase("bread")]
        [TestCase("toast")]
        [TestCase("thing")]
        public void Test003_BreadFirstTranslationNameIsBread(string word)
        {
            //Arrange
            var url = @$"https://www.wordreference.com/enfr/{word}";
            GetMock<IScrapeTarget>().SetupGet(t => t.URL).Returns(url);

            //Act
            scraper.Scrape(GetObject<IScrapeTarget>());

            //Assert
            GetMock<IDatabaseFeeder>().Verify(f => f.Feed(It.Is<IEnumerable<ITranslation>>(l => l.First().Word == word)));
        }

        [TestCase("bread", "uncountable (type of food)")]
        [TestCase("toast", "uncountable (bread)")]
        [TestCase("thing", "(single object)")]
        public void Test004_GetEnglishDetails(string word, string expectedDetails)
        {
            //Arrange
            var url = @$"https://www.wordreference.com/enfr/{word}";
            GetMock<IScrapeTarget>().SetupGet(t => t.URL).Returns(url);

            //Act
            scraper.Scrape(GetObject<IScrapeTarget>());

            //Assert
            GetMock<IDatabaseFeeder>().Verify(f => f.Feed(It.Is<IEnumerable<ITranslation>>(l => l.First().EnglishDetails == expectedDetails)));
        }

        [TestCase("bread", "pain")]
        [TestCase("toast", "pain grillé")]
        [TestCase("thing", "chose")]
        public void Test005_GetFrenchTranslation(string word, string expected)
        {
            //Arrange
            var url = @$"https://www.wordreference.com/enfr/{word}";
            GetMock<IScrapeTarget>().SetupGet(t => t.URL).Returns(url);

            //Act
            scraper.Scrape(GetObject<IScrapeTarget>());

            //Assert
            GetMock<IDatabaseFeeder>().Verify(f => f.Feed(It.Is<IEnumerable<ITranslation>>(l => l.First().FrenchTranslations == expected)));
        }

        [TestCase("bread", "You can't make a sandwich without bread. On ne peut pas faire de sandwich sans pain.")]
        [TestCase("toast", "Would you like some toast with your breakfast?  I'd like two slices of toast, please. Veux-tu du pain grillé avec ton petit déjeuner ?  Je voudrais deux tranches de pain grillé, s'il vous plaît.")]
        [TestCase("thing", "I'm not sure what this thing is. Je ne suis pas sûr de ce qu'est cette chose.")]
        public void Test006_GetExample(string word, string expected)
        {
            //Arrange
            var url = @$"https://www.wordreference.com/enfr/{word}";
            GetMock<IScrapeTarget>().SetupGet(t => t.URL).Returns(url);

            //Act
            scraper.Scrape(GetObject<IScrapeTarget>());

            //Assert
            GetMock<IDatabaseFeeder>().Verify(f => f.Feed(It.Is<IEnumerable<ITranslation>>(l => l.First().Example == expected)));
        }
    }
}
