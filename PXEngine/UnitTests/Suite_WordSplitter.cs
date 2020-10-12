using NUnit.Framework;
using DXProject.Splitting;
using DXProject.Testing;
using System.Collections.Generic;

namespace UnitTests
{
    public class Suite_WordSplitter : BaseUnitTesting
    {
        [Test]
        public void Test001a_Split_VerifySplitWorks()
        {
            //Arrange
            var l = "blabla kiki";
            var ws = new WordSplitter(l);

            //Act
            var r = ws.Split();

            //Assert
            Assert.AreEqual(new List<string>() { "blabla", "kiki" }, r);
        }
    }
}
