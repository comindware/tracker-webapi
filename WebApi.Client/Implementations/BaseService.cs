// ***********************************************************************
// <author>Vasiliy Shapenko</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2016. All rights reserved.
// </copyright>
// <summary>
//   BaseService.cs
// </summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Comindware.Platform.WebApi.Contracts;
using RestSharp;
using RestSharp.Authenticators;

namespace Comindware.Platform.WebApi.Client
{
    public abstract class BaseService
    {
        protected BaseService(InterfaceInstanceParameters creationParameters)
        {
            this.CreationParameters = creationParameters;
        }

        public InterfaceInstanceParameters CreationParameters { get; private set; }

        protected WebRequestCreationParameters CreateParameters(Method method, string query, IDictionary<string, string> queryParameters)
        {
            return new WebRequestCreationParameters
            {
                ContentType = "application/json",
                Method = method,
                Query = query,
                Secret = this.CreationParameters.Secret,
                Token = this.CreationParameters.Token,
                Uri = this.CreationParameters.Uri,
                QueryParameters = queryParameters
            };
        }

        protected WebRequestCreationParameters CreateParameters(Method method, string query, IDictionary<string, List<string>> queryParameters)
        {
            return new WebRequestCreationParameters
            {
                ContentType = "application/json",
                Method = method,
                Query = query,
                Secret = this.CreationParameters.Secret,
                Token = this.CreationParameters.Token,
                Uri = this.CreationParameters.Uri,
                ListQueryParameters = queryParameters
            };
        }

        protected T GetResponseResult<T>(IRestResponse responseRaw)
        {
            CheckStatusCode(responseRaw);

            var response = ClientJsonSerializer.ToObject<WebApiResponse<T>>(responseRaw.Content);

            if (response.Error == null)
                return response.Response;

            this.ThrowExceptionIfHasResponseError(response.Error, response.Response);

            return default(T);
        }

        private void ThrowExceptionIfHasResponseError(WebApiError error, object response)
        {
            if (response is BulkOperationResult)
            {
                var bulkOperationResponse = response as BulkOperationResult;

                throw new BulkOperationClientException(
                    errors: bulkOperationResponse.SubOperations.Select(data => data.Error)
                );
            }

            if (error == null)
                return;

            if (error.Type.Equals(typeof(WebApiClientException).Name))
            {
                throw new WebApiClientException(error.Message);
            }

            ExceptionHelper.Throw(error);
        }

        protected FileContent GetResponseFileResult(IRestResponse responseRaw)
        {
            CheckStatusCode(responseRaw);
            WebApiResponse<FileContent> response;

            if (responseRaw.ContentType != "application/octet-stream" && !responseRaw.ContentType.Contains("application/json"))
            {
                throw new Exception("Wrong content type: " + responseRaw.ContentType); //ToDo create new exception type
            }

            if (responseRaw.ContentType.Contains("application/json")) //if thrown exception
            {
                response = ClientJsonSerializer.ToObject<WebApiResponse<FileContent>>(responseRaw.Content);
            }
            else
            {
                var data = responseRaw.RawBytes;
                var header = responseRaw.Headers.FirstOrDefault(h => h.Name == "Content-Disposition");
                string name = string.Empty;
                if (header != null)
                {
                    var headerValue = ContentDispositionHeaderValue.Parse(header.Value.ToString());
                    name = headerValue.FileNameStar;
                }

                var result = new FileContent(data, name);

                response = new WebApiResponse<FileContent>
                {
                    Error = null,
                    Response = result,
                    Success = true
                };
            }

            this.ThrowExceptionIfHasResponseError(response.Error, response.Response);
            return response.Response;
        }

        protected void CheckStatusCode(IRestResponse response)
        {
            var statusCode = (int)response.StatusCode;
            if (statusCode > 400)
            {
                throw new ErrorStatusCodeClientException(statusCode, response.Content);
            }
        }

        protected IRestResponse ProcessRequest(Method method, string address, Dictionary<string, string> queryParameters = null, object content = null)
        {
            var processingParameters = this.CreateParameters(method, address, queryParameters);
            var body = content == null
                ? null
                : ClientJsonSerializer.ToJson(content);
            var result = ProcessRequest(processingParameters, body);
            return result;
        }

        protected IRestResponse ProcessRequest(Method method, string address, Dictionary<string, List<string>> queryParameters, object content = null)
        {
            var processingParameters = this.CreateParameters(method, address, queryParameters);
            var body = content == null
                ? null
                : ClientJsonSerializer.ToJson(content);
            var result = ProcessRequest(processingParameters, body);
            return result;
        }

        protected IRestResponse ProcessFileBodyRequest(Method method, string address, Dictionary<string, string> queryParameters = null, FileContent file = null)
        {
            var processingParameters = this.CreateParameters(method, address, queryParameters);
            var result = this.ProcessFileRequest(processingParameters, file);
            return result;
        }

        private RestClient CreateClient(string uri, string query, string token, string secret)
        {
            var client = new RestClient(new Uri(new Uri(uri), query))
            {
                Authenticator = new HttpBasicAuthenticator(token, secret)
            };

            if (CreationParameters.AuthenticationType != AuthenticationType.ApiKey && CreationParameters.AuthenticationType != AuthenticationType.HMAC)
            {
                switch (CreationParameters.AuthenticationType)
                {
                    case AuthenticationType.NtlmUsingDefaultCredentialsFromCache:
                        client.Authenticator = new NtlmAuthenticator(CredentialCache.DefaultNetworkCredentials);
                        break;
                    case AuthenticationType.NtlmUsingStoredCredentialsFromCache:
                        client.Authenticator = new NtlmAuthenticator(CredentialCache.DefaultNetworkCredentials.GetCredential(new Uri(uri), ""));
                        break;
                    case AuthenticationType.NtlmUsingCustomCredentials:
                        client.Authenticator = new NtlmAuthenticator(new NetworkCredential(CreationParameters.NtlmUserName, CreationParameters.NtlmUserPassword));
                        break;
                    case AuthenticationType.NtlmCurrentUser:
                        client.Authenticator = new NtlmAuthenticator();
                        break;
                }
            }
            return client;
        }

        private RestRequest CreateRequest(WebRequestCreationParameters parameters, object content)
        {
            var request = new RestRequest(parameters.Method);
            request.AddParameter(parameters.ContentType, content, ParameterType.RequestBody);
            request.AddParameter("Content-Type", parameters.ContentType, ParameterType.HttpHeader);
            if (parameters.QueryParameters != null)
            {
                foreach (var parameter in parameters.QueryParameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value);
                }
            }
            if (parameters.ListQueryParameters != null)
            {
                foreach (var parameter in parameters.ListQueryParameters)
                {
                    foreach (var val in parameter.Value)
                    {
                        request.AddQueryParameter(parameter.Key, val);
                    }
                }
            }
            return request;
        }

        private RestRequest CreateFileRequest(WebRequestCreationParameters parameters, FileContent file)
        {
            var request = new RestRequest(parameters.Method);

            if (file != null)
            {
                request.AddFile("file", file.Content, file.FileName);
                using (var hasher = MD5.Create())
                {
                    //Adding content-md5 header to store file hash
                    var contentHash = Convert.ToBase64String(hasher.ComputeHash(file.Content));
                    request.AddParameter("Content-MD5", contentHash, ParameterType.HttpHeader);
                }
            }
            //Adding stub for header - will be used in hash calculating
            request.AddParameter("Content-Type", "multipart/form-data", ParameterType.HttpHeader);

            if (parameters.QueryParameters != null)
            {
                foreach (var parameter in parameters.QueryParameters)
                {
                    request.AddQueryParameter(parameter.Key, parameter.Value);
                }
            }
            return request;
        }

        private void FillHmacHeader(RestRequest request, Uri absolutePath, string token, string secretKey)
        {
            var headers = request.Parameters.Where(p => p.Type == ParameterType.HttpHeader).ToDictionary(h => h.Name, h => h.Value);

            var headerNames = new[] { "Date", "Expires", "Content-Type" };

            var stringToSign = string.Empty;

            //First,we are taking method plus path.
            stringToSign += string.Join("\n", request.Method.ToString(), absolutePath.AbsolutePath.ToLower());

            //Adding involved headers
            foreach (var headerName in headerNames)
            {
                object value;
                if (!headers.TryGetValue(headerName, out value))
                {
                    value = string.Empty;
                }
                stringToSign = string.Join("\n", stringToSign, value);
            }

            //If we have Content-MD5 header,we should get content hash from its value,otherwise,try to calculate body hash.
            var contentHash = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.HttpHeader && p.Name.Equals("Content-MD5", StringComparison.OrdinalIgnoreCase));
            if (contentHash != null)
            {
                stringToSign = string.Join("\n", stringToSign, contentHash.Value);
            }
            else
            {
                var body = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
                if (body != null)
                {
                    using (var hasher = MD5.Create())
                    {
                        byte[] hash = new byte[0];

                        if (body.Value is Stream)
                        {
                            hash = hasher.ComputeHash(body.Value as Stream);
                        }
                        else if (body.Value is byte[])
                        {
                            hash = hasher.ComputeHash(body.Value as byte[]);
                        }
                        else
                        {
                            hash = hasher.ComputeHash(
                                Encoding.UTF8.GetBytes(
                                    body.Value == null
                                        ? string.Empty
                                        : body.Value.ToString()));
                        }
                        //Adding MD5 content signature                 
                        stringToSign = string.Join("\n", stringToSign, Convert.ToBase64String(hash));
                    }
                }
            }

            //Using user secret as key for HMAC
            if (CreationParameters.AuthenticationType != AuthenticationType.None)
            {
                var secretKeyBytes = Convert.FromBase64String(secretKey);
                using (var hmac = new HMACSHA512(secretKeyBytes))
                {
                    byte[] stringToSignData = Encoding.UTF8.GetBytes(stringToSign);
                    var signatureBytes = hmac.ComputeHash(stringToSignData);
                    var signature = Convert.ToBase64String(signatureBytes);
                    if (CreationParameters.AuthenticationType == AuthenticationType.HMAC)
                    {
                        var headerValue = string.Format("{0} {1}:{2}", "HMAC", token, signature);
                        request.Parameters.Add(new Parameter
                        {
                            Name = "Authorization",
                            Type = ParameterType.HttpHeader,
                            Value = headerValue
                        });
                    }
                    else
                    {
                        var headerValue = string.Format("{0}", token);
                        request.Parameters.Add(new Parameter
                        {
                            Name = "apiKey",
                            Type = ParameterType.HttpHeader,
                            Value = headerValue
                        });
                    }
                }
            }
        }

        private IRestResponse ProcessRequest(WebRequestCreationParameters parameters, object content)
        {
            var client = this.CreateClient(parameters.Uri, parameters.Query, parameters.Token, parameters.Secret);
            var request = this.CreateRequest(parameters, content);
            this.FillHmacHeader(request, client.BaseUrl, parameters.Token, parameters.Secret);
            var response = client.Execute(request);
            return response;
        }

        private IRestResponse ProcessFileRequest(WebRequestCreationParameters parameters, FileContent file)
        {
            var client = this.CreateClient(parameters.Uri, parameters.Query, parameters.Token, parameters.Secret);
            var request = this.CreateFileRequest(parameters, file);
            this.FillHmacHeader(request, client.BaseUrl, parameters.Token, parameters.Secret);
            var response = client.Execute(request);
            return response;
        }
    }
}
