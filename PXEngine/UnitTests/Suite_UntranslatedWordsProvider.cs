using DXProject.Database;
using DXProject.Models;
using DXProject.Scraping;
using DXProject.Testing;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class Suite_UntranslatedWordsProvider : BaseUnitTesting
    {
        UntranslatedWordsProvider translationCompleter;

        protected override void Setup()
        {
            base.Setup();
            translationCompleter = new UntranslatedWordsProvider(GetObject<IDataProvider>());
        }


        [Test]
        public void Test001_MissingWordInAListOfTwoIsCorrectlyReturned()
        {
            // Arrange
            var words = new List<Word>();
            words.Add(new Word() { Name = "blabla" });
            words.Add(new Word() { Name = "kiki" });
            GetMock<IDataProvider>().Setup(a => a.GetAll<Word>()).Returns(words);

            var translations = new List<Translation>();
            translations.Add(new Translation() { Word = "blabla" });
            GetMock<IDataProvider>().Setup(a => a.GetAll<Translation>()).Returns(translations);

            // Act
            var missingWords = translationCompleter.GetAll();

            // Assert
            Assert.AreEqual(1, missingWords.Count());
            Assert.AreEqual("kiki", missingWords.First());
        }
    }
}
