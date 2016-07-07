using System.Collections.Generic;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class FavoriteService:BaseService,IFavoriteService
    {
        public FavoriteService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        public void AddToFavorites(string id)
        {
            var address = "Api/Favorites/" + id;
            var result = ProcessRequest(Method.POST, address);
        }

        public void RemoveFromFavorites(string id)
        {
            var address = "Api/Favorites/" + id;
            var result = ProcessRequest(Method.DELETE, address);
        }

        public IEnumerable<InstanceModel> GetFavorites()
        {
            var address = "Api/Favorites";
            var result = ProcessRequest(Method.GET, address);
            return GetResponseResult<IEnumerable<InstanceModel>>(result);
        }
    }
}