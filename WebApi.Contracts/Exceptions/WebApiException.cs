using System;

namespace Comindware.Platform.WebApi.Contracts
{
    /// <summary>
    /// Base web Api Exceptions
    /// </summary>
    public abstract class WebApiException : ApplicationException
    {
        protected WebApiException()
        { }

        protected WebApiException(string message)
            : base(message)
        { }
    }
}
