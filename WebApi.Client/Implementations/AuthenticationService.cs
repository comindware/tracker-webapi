using Comindware.Platform.WebApi.Contracts;
using RestSharp;

namespace Comindware.Platform.WebApi.Client
{
    public class AuthenticationService:BaseService,IAuthenticationService
    {
        public AuthenticationService(InterfaceInstanceParameters creationParameters) : base(creationParameters)
        {
        }

        public CredentialPair IssueTokenByLoginAndPassword(CredentialPair userCredentials)
        {
            var queryString = "Authentication/IssueToken";
            var result = this.ProcessRequest(Method.POST, queryString,content:userCredentials);
            return this.GetResponseResult<CredentialPair>(result);
        }

        public string LoginByToken(string token)
        {
            var queryString = string.Format("Authentication/LoginByToken/{0}",token);
            var result = this.ProcessRequest(Method.GET, queryString);
            return this.GetResponseResult<string>(result);
        }
    }
}