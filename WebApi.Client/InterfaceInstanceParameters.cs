namespace Comindware.Platform.WebApi.Client
{
    public class InterfaceInstanceParameters
    {
        public string Uri { get; set; }

        public string Token { get; set; }

        public string Secret { get; set; }

        public AuthenticationType AuthenticationType { get; set; }

        public string NtlmUserName { get; set; }

        public string NtlmUserPassword { get; set; }


    }

    public enum AuthenticationType
    {
        None,
        HMAC,
        ApiKey,
        NtlmUsingDefaultCredentialsFromCache,
        NtlmUsingStoredCredentialsFromCache,
        NtlmUsingCustomCredentials,
        NtlmCurrentUser
    }
}