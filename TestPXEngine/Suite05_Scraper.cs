using DXProject.Testing;
using NUnit.Framework;
using SXScraper;
using SXScraper.Scraping;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests
{
    public class Suite05_Scraper : BaseUnitTesting
    {
        private WordReferenceScraper scraper;

        private string CreateLocalURL(string word)
        {
            return @$"C:\Users\felix\source\repos\PXApi\TestPXEngine\Data\WordReferencePages\{word}.html";
        }

        protected override void Setup()
        {
            base.Setup();

            GetMock<IWordReferenceURLBuilder>().Setup(b => b.Build(GetAny<string>())).Returns((string word) => CreateLocalURL(word));

            scraper = new WordReferenceScraper(new HtmlDocumentFactory(), GetObject<IWordReferenceURLBuilder>(), new CaretAnalyser(new UseLessStringCleaner()));
        }

        [Test]
        public void Test002_FeederIsCalledOnce()
        {
            //Act
            var r = scraper.Scrape("bread");

            //Assert
            Assert.AreEqual(1, r.Count);
        }

        [TestCase("bread")]
        [TestCase("toast")]
        [TestCase("thing")]
        [TestCase("realized")]
        [TestCase("low")]
        public void Test003_FirstTranslationNameIsTheWord(string word)
        {
            //Act
            var r = scraper.Scrape(word);

            //Assert
            Assert.AreEqual(word, r[0].Word);
        }

        [TestCase("bread", "uncountable (type of food)")]
        [TestCase("toast", "uncountable (bread)")]
        [TestCase("thing", "(single object)")]
        public void Test004_GetEnglishDetails(string word, string expectedDetails)
        {
            //Arrange

            //Act
            var r = scraper.Scrape(word);


            //Assert
            Assert.AreEqual(expectedDetails, r[0].EnglishDetails);
        }

        [TestCase("bread", "pain")]
        [TestCase("toast", "pain grillé")]
        [TestCase("thing", "chose")]
        public void Test005_GetFrenchTranslation(string word, string expected)
        {
            //Arrange

            //Act
            var r = scraper.Scrape(word);

            //Assert
            Assert.AreEqual(expected, r[0].FrenchTranslations);
        }

        [TestCase("bread", "You can't make a sandwich without bread. On ne peut pas faire de sandwich sans pain.")]
        [TestCase("toast", "Would you like some toast with your breakfast?  I'd like two slices of toast, please. Veux-tu du pain grillé avec ton petit déjeuner ?  Je voudrais deux tranches de pain grillé, s'il vous plaît.")]
        [TestCase("thing", "I'm not sure what this thing is. Je ne suis pas sûr de ce qu'est cette chose.")]
        public void Test006_GetExample(string word, string expected)
        {
            //Arrange

            //Act
            var r = scraper.Scrape(word);


            //Assert
            Assert.AreEqual(expected, r[0].Example);
        }

        [TestCase("dffhgsgfh")]
        public void Test007_IfWordDoesntExistThenDoNotCrash(string word)
        {
            //Act
            var r = scraper.Scrape(word);

            //Assert
            Assert.IsEmpty(r);
        }
    }
}
