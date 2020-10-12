using DXProject.Models;
using DXProject.Testing;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Suite_Request : BaseUnitTesting
    {
        Request request;

        protected override void Setup()
        {
            base.Setup();
            request = new Request();
        }


        [TestCase(0)]
        [TestCase(45)]
        public void Ctor_IDIsGetSettable(int id)
        {
            request.Id = id;
            Assert.AreEqual(id, request.Id);
        }

        [TestCase("wdfgdfg")]
        [TestCase("fdxgg")]
        public void Ctor_IDIsGetSettable(string requestContent)
        {
            request.RequestURL = requestContent;
            Assert.AreEqual(requestContent, request.RequestURL);
        }
    }
}
