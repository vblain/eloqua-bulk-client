using RestSharp;
using EloquaBulkClient.Models.Common;

namespace EloquaBulkClient
{
    public sealed class Client : RestClient
    {
        private readonly RestClient _client;

        public Client(string site, string user, string password, string baseUrl)
        {
            _client = new RestClient
                {
                    BaseUrl = baseUrl,
                    Authenticator = new HttpBasicAuthenticator(site + "\\" + user, password)
                };
        }

        internal new T Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response = _client.Execute<T>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw response.ErrorException;
            }
            return response.Data;
        }

        public T Get<T>(int id) where T : ContractObject, new()
        {
            var item = new T { id = id };
            var request = Request.Get(Request.Type.Get, item);
            return Execute<T>(request);
        }

        public void Delete<T>(int? id) where T : ContractObject, new()
        {
            var item = new T { id = id };
            var request = Request.Get(Request.Type.Delete, item);
            Execute<T>(request);
        }

        public T Post<T>(T restObj) where T : ContractObject, new()
        {
            var request = Request.Get(Request.Type.Post, restObj);
            return Execute<T>(request);
        }

        public T Put<T>(T restObj) where T : ContractObject, new()
        {
            var request = Request.Get(Request.Type.Put, restObj);
            return Execute<T>(request);
        }

        public SearchResponse<T> Search<T>(string searchTerm, int pageNumber, int pageSize) where T : ContractObject, ISearchable, new()
        {
            var items = new T { searchTerm = searchTerm, page = pageNumber, pageSize = pageSize };
            var request = Request.Get(Request.Type.Search, items);
            return Execute<SearchResponse<T>>(request);
        }
    }
}
