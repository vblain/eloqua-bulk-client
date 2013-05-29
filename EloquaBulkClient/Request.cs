using System;
using System.Text;
using EloquaBulkClient.Models;
using EloquaBulkClient.Models.Common;
using RestSharp;

namespace EloquaBulkClient
{
    public class Request
    {
        internal enum Type
        {
            Delete,
            Get,
            Post,
            Put,
            Search
        }

        internal static RestRequest Get(Type type, ContractObject restObj)
        {
            restObj.type = restObj.Type;

            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json
            };

            switch (type)
            {
                case Type.Get:
                    request.Method = Method.GET;
                    request.Resource = restObj.Uri + "/" + restObj.id + "?depth=" + restObj.depth;
                    break;

                case Type.Put:
                    request.Method = Method.PUT;
                    request.Resource = restObj.Uri + "/" + restObj.id;
                    request.AddBody(restObj);
                    break;

                case Type.Post:
                    request.Method = Method.POST;
                    request.Resource = restObj.Uri;
                    request.AddBody(restObj);
                    break;

                case Type.Delete:
                    request.Method = Method.DELETE;
                    request.Resource = restObj.Uri + "/" + restObj.id;
                    break;

                case Type.Search:
                    request.Method = Method.GET;

                    var resource = new StringBuilder(100);
                    resource.Append(restObj.Uri);
                    resource.Append("s"); // pluralize the endpoint

                    var searchObj = restObj as ISearchable;
                    resource.Append("?search=" + searchObj.searchTerm +
                                    "&count=" + searchObj.pageSize +
                                    "&page=" + searchObj.page
                                    );

                    request.Resource = resource.ToString();

                    break;

                default:
                    throw new NotSupportedException(type.ToString());
            }
            return request;
        }
    }
}
