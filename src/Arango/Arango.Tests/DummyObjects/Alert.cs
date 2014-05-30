using System.Collections.Generic;
using Arango.Client;
using System;

namespace Arango.Tests
{
	public class Alert
	{
		[ArangoProperty(Identity = true)]
		public string ThisIsId { get; set; }
		
		[ArangoProperty(Key = true)]
		public string ThisIsKey { get; set; }
		
		[ArangoProperty(Revision = true)]
		public string ThisIsRevision { get; set; }

		
        [ArangoProperty(Serializable = false)]
        public string ShouldBeOnlyDeserialized { get; set; }
        
        [ArangoProperty(Serializable = false, Deserializable = false)]
        public string ShouldNotBeSerializedOrDeserialized { get; set; }
        
        [ArangoProperty(Alias = "aliasedField")]
        public string Aliased { get; set; }
		public Dictionary<string, DateTime> PurchasedBy {get; set;}
		public    Dictionary<string, Dictionary<string, Person>> Relations {get; set;}
		public int StatusCode {get; set;}
		public bool Success {get; set; }
		
		public Alert()
		{
			PurchasedBy = new Dictionary<string, DateTime>();
		}
	}
}
