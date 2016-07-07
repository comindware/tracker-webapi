using System;
using System.Collections.Generic;
using System.Linq;
using Comindware.Platform.WebApi.Contracts;

namespace Comindware.Platform.WebApi.Client
{
    public static class ExceptionHelper
    {
        private static List<Type> _exceptionTypes;

        static ExceptionHelper()
        {
            if (_exceptionTypes == null)
            {
                var webApiExceptionType = typeof (WebApiException);
                var assem = webApiExceptionType.Assembly;
                _exceptionTypes = assem.GetTypes().Where(x => x.IsSubclassOf(webApiExceptionType)).ToList();
            }
        }

        public static void Throw(WebApiError error)
        {
            if (_exceptionTypes != null)
            {
                var exceptionType = _exceptionTypes.FirstOrDefault(type => type.Name.Equals(error.Type));
                if (exceptionType != null)
                {
                    var exception = (WebApiException)Activator.CreateInstance(exceptionType, new object[] { error });
                    throw exception;
                }
            }

            throw new WebApiClientException(error.Message);
        }
    }
}
