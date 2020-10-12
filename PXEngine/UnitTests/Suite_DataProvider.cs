using DXProject.Database;
using DXProject.Models;
using DXProject.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class Suite_DataProvider : BaseUnitTesting
    {
        DataProvider provider;

        protected override void Setup()
        {
            base.Setup();
            provider = new DataProvider(GetObject<IPXDbContext>());
        }


        [Test]
        public void ProvideAll_WordReturnsAllFromContext()
        {
            //Arrange
            var words = GetMock<DbSet<Word>>();
            GetMock<IPXDbContext>().SetupGet(c => c.Words).Returns(words.Object);
            
                // Act
            var result = provider.GetAll<Word>();

            // Assert
            Assert.AreEqual(GetObject<DbSet<Word>>(), result);
        }

        [Test]
        public void ProvideAll_TranslationReturnsAllFromContext()
        {
            //Arrange
            var translations = GetMock<DbSet<Translation>>();
            GetMock<IPXDbContext>().SetupGet(c => c.Translations).Returns(translations.Object);

            // Act
            var result = provider.GetAll<Translation>();

            // Assert
            Assert.AreEqual(GetObject<DbSet<Translation>>(), result);
        }

        [Test]
        public void ProvideAll_ReturnsAnExceptionIfTypeIsNotSupported()
        {
            // Assert
            Assert.Throws(typeof(Exception), ()=> provider.GetAll<DataProvider>());
        }
    }
}
