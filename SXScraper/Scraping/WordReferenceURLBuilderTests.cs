using DXProject.Testing;
using Moq;
using NUnit.Framework;
using SXScraper;
using System;

namespace UnitTests
{
    [TestFixture]
    public class WordReferenceURLBuilderTests : BaseUnitTesting
    {
        WordReferenceURLBuilder wordReferenceURLBuilder;

        protected override void Setup()
        {
            base.Setup();
            wordReferenceURLBuilder = new WordReferenceURLBuilder();
        }


        [Test]
        public void Build_URLIsTheOneNeededForWordReference()
        {
            // Arrange
            var word = "bread";

            // Act
            var url = wordReferenceURLBuilder.Build(word);

            // Assert
            Assert.AreEqual(@"https://www.wordreference.com/enfr/bread", url);
        }
    }
}
