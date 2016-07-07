using System.Collections.Generic;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class WebRequestCreationParameters
    {
        public string Uri { get; set; }
        public string Token { get; set; }
        public string Secret { get; set; }
        public Method Method { get; set; }
        public string ContentType { get; set; }
        public string Query { get; set; }
        public IDictionary<string, string> QueryParameters { get; set; }
    }
}