using DXProject.Database;
using DXProject.Models;
using DXProject.Testing;
using NUnit.Framework;
using SXDatabase;

namespace UnitTests
{
    public class Suite_DatabaseConnector : BaseUnitTesting
    {
        DatabaseConnector accesser; 
        protected override void Setup()
        {
            base.Setup();
            accesser = new DatabaseConnector();
        }
    }
}
