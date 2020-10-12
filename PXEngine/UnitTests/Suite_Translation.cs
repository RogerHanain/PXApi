using DXProject.Models;
using DXProject.Testing;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Suite_Translation : BaseUnitTesting
    {
        Translation translation;

        protected override void Setup()
        {
            base.Setup();
            translation = new Translation();
        }


        [TestCase(45)]
        [TestCase(37410)]
        public void Ctor_IDIsGetSettable(int id)
        {
            translation.Id = id;
            Assert.AreEqual(id, translation.Id);
        }

        [TestCase("wfdgdfh")]
        public void Ctor_NameWithTypeGetSettable(string name)
        {
            translation.NameWithType = name;
            Assert.AreEqual(name, translation.NameWithType);
        }
    }
}
