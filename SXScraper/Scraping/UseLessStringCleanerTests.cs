using DXProject.Testing;
using Moq;
using NUnit.Framework;
using SXScraper.Scraping;
using System;

namespace UnitTests
{
    [TestFixture]
    public class UseLessStringCleanerTests : BaseUnitTesting
    {
        UseLessStringCleaner useLessStringCleaner;

        protected override void Setup()
        {
            base.Setup();
            useLessStringCleaner = new UseLessStringCleaner();
        }


        [TestCase("blabla nnoun: Refers to person, place, thing, quality, etc.","blabla")]
        public void Clean_CheckTheLongUselessContentIsRemoved(string toBeCleaned, string expectedResult)
        {
            // Act
            var result = useLessStringCleaner.Clean(toBeCleaned);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
