namespace Comindware.Platform.WebApi.Contracts
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Tries to authenticate user and returns authentication result containing result and user token  if succeded.
        /// </summary>
        /// <param name="userCredentials">User credentials.</param>
        /// <returns>Api token.</returns>
        CredentialPair IssueTokenByLoginAndPassword(CredentialPair userCredentials);

        /// <summary>
        /// Tries to login user by api token.
        /// </summary>
        /// <param name="token">Api token.</param>
        /// <returns>Session id if login success, null otherwise.</returns>
        string LoginByToken(string token);

    }
}