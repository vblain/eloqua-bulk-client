using EloquaBulkClient;
using EloquaBulkClient.Models.Common;
using EloquaBulkClient.Models.Filters;
using NUnit.Framework;

namespace EloquaBulkClientTests.Filters
{
    [TestFixture]
    public class ContactFilterTests
    {
        private Client _client;

        [TestFixtureSetUp]
        public void Init()
        {
            _client = new Client("site", "user", "password", "https://secure.eloqua.com/API/Bulk/1.0/");
        }

        [Test]
        public void GetContactFiltersTest()
        {
            SearchResponse<ContactFilter> response = _client.Search<ContactFilter>("*", 1, 10);
            Assert.Greater(response.elements.Count, 0);
        }
    }
}
