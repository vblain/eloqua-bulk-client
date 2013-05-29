using EloquaBulkClient;
using EloquaBulkClient.Models.Common;
using EloquaBulkClient.Models.Fields;
using NUnit.Framework;

namespace EloquaBulkClientTests.Fields
{
    [TestFixture]
    public class ContactFieldTests
    {
        private Client _client;

        [TestFixtureSetUp]
        public void Init()
        {
            _client = new Client("site", "user", "password", "https://secure.eloqua.com/API/Bulk/1.0/");
        }

        [Test]
        public void GetContactFieldTest()
        {
            SearchResponse<ContactField> response = _client.Search<ContactField>("*", 1, 10);
            Assert.Greater(response.elements.Count, 0);
        }
    }
}
