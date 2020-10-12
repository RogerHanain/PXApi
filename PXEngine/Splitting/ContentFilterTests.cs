using NUnit.Framework;
using DXProject.Splitting;
using DXProject.Testing;
using System.Collections.Generic;

namespace UnitTests
{
    public class ContentFilterTests : BaseUnitTesting
    {
        [Test]
        public void Test001a_Filter_AllDifferentKeepsTheSame()
        {
            //Arrange
            var source = new ContentFilter();

            //Act
            var r = source.Filter(new List<string>() { "a", "b" });

            //Assert
            Assert.AreEqual(new List<string>() {"a", "b" }, r);
        }

        [Test]
        public void Test001b_Filter_FilterDuplicates()
        {
            //Arrange
            var source = new ContentFilter();

            //Act
            var r = source.Filter(new List<string>() { "caca", "b", "caca" });

            //Assert
            Assert.AreEqual(new List<string>() { "caca", "b" }, r);
        }
    }
}
