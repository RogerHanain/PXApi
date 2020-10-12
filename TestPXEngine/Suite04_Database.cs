using DXProject.Database;
using NUnit.Framework;
using SXDatabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests
{
    public class Suite04_Database
    {
        [Test]
        public void Test001a_ReturnsADBContext()
        {
            DatabaseConnector accesser = new DatabaseConnector();

            var context = accesser.ConnectToDB();

            //Assert
            Assert.IsTrue(context is IPXDbContext);
        }
    }
}
