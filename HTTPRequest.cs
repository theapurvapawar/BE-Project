using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace ObjectStore
{
    internal class HTTPRequest : System.Net.WebRequest
    //This class creates HTTP Request.
    {
        Client client;
        internal WebRequest request;
        protected String method;

        internal HTTPRequest()
        {

        }

        internal HTTPRequest(Client client)
        {
            this.client = client;
        }

        private void addHeader(string headerName, string headerValue)
        {
            request.Headers.Add(headerName, headerValue);
        }

        internal void createHTTPRequest(String RequestType)
        {
            if (RequestType == Resource1.AuthRequest)
            {
                request = WebRequest.Create(RequestUtil.formAuthURL(client));
                addHeader(CommonConstants.X_STORAGE_USER_CONSTANT,
                    client.username + ":" + client.groupname);
                addHeader(CommonConstants.X_STORAGE_PASS_CONSTANT,
                    client.password);
            }

            if (RequestType == Resource1.AccountRequest)
            {
                request = WebRequest.Create(RequestUtil.formAccountURL(client));
                addHeader(CommonConstants.X_AUTH_TOKEN_CONSTANT,
                    client.token);
                addHeader(CommonConstants.X_CDMI_VERSION_CONSTANT,
                    CommonConstants.X_CDMI_VERSION_VALUE_CONSTANT);
            }
            request.Method = method;
        }

        internal void createHTTPRequest(String path, String RequestType)
        {
            if (RequestType == Resource1.ContainerRequest)
            {
                request = WebRequest.Create(RequestUtil.formContainerURL(client, path));
                addHeader(CommonConstants.X_AUTH_TOKEN_CONSTANT,
                    client.token);
                addHeader(CommonConstants.X_CDMI_VERSION_CONSTANT,
                    CommonConstants.X_CDMI_VERSION_VALUE_CONSTANT);
                request.ContentType = CommonConstants.CDMI_CONTAINER_CONSTANT;
            }
            if (RequestType == Resource1.ObjectRequest)
            {
                request = WebRequest.Create(RequestUtil.formObjectURL(client, path));
                addHeader(CommonConstants.X_AUTH_TOKEN_CONSTANT,
                    client.token);
                addHeader(CommonConstants.X_CDMI_VERSION_CONSTANT,
                    CommonConstants.X_CDMI_VERSION_VALUE_CONSTANT);
                request.ContentType = CommonConstants.CDMI_OBJECT_CONSTANT;
            }
            request.Method = method;
        }

        internal ExecutionResult executeRequest()
        {
            try
            {
                return RequestExecutor.executeRequest(this);
            }
            catch (ExceptionHandler)
            {
                throw;
            }
        }

        public override System.Net.WebResponse GetResponse()
        {
            try
            {
                WebResponse response = request.GetResponse();
                return response;
            }
            catch (System.Net.WebException webException)
            {
                throw new ExceptionHandler(webException.Message);
            }
        }

    }
}
