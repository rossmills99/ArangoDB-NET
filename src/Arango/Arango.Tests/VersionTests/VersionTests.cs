using System;
using NUnit.Framework;
using Arango.Client;
using System.Text.RegularExpressions;

namespace Arango.Tests.VersionTests
{
    [TestFixture()]
    public class ArangoVersionTests : IDisposable
    {
    	public ArangoVersionTests()
    	{
    	       Database.CreateTestDatabase(Database.TestDatabaseGeneral);
    	}
    	
        [Test()]
        public void Should_read_version()
        {
        	var db = Database.GetTestDatabase();
        	ArangoVersion version = db.Version.Get();
        	
        	Assert.IsTrue(version.Major >= 1);
        	Assert.IsTrue(version.Minor >= 0);
        	Assert.IsTrue(version.PatchLevel >= 0);
        	
        	Assert.IsTrue(version.toInt() >= 10300);
        	
        	Regex re = new Regex(@"^\d+\.\d+\.\d+.*$");
        	Assert.IsTrue(re.IsMatch(version.Version));
        }

        [Test()]
        public void Should_convert_to_int()
        {
            ArangoVersion version = new ArangoVersion("2.1.0");
            Assert.IsTrue(version.toInt() == 20100);

            version = new ArangoVersion("2.0.0");
            Assert.IsTrue(version.toInt() == 20000);

            version = new ArangoVersion("1.4.8");
            Assert.IsTrue(version.toInt() == 10408);
        }
        
        public void Dispose()
        {
        	Database.DeleteTestDatabase(Database.TestDatabaseGeneral);
        }
    }
}
