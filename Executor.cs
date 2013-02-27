using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace ObjectStore
{
    public class HTTPRequest: System.Net.WebRequest
    {
        public Client client;
        public WebRequest request;
        public HTTPRequest()
        { 
        }
        public HTTPRequest(Client client)
        {
            this.client = client;
        }

        public void makeHTTPRequest()
        {
               request = WebRequest.Create(Util.formAuthURL(client));
        }

        public ExecutionResult executeRequest()
        {
           
            return RequestExecutor.executeRequest(this);
        }

        public override System.Net.WebResponse GetResponse()
        {
            WebResponse response = request.GetResponse();
            return response;
        }
    }

    public class GetHTTPRequest : HTTPRequest
    {
        public GetHTTPRequest(Client client)
        {
            //request.Method = "GET";
        }
    }

    public class PutHTTPRequest : HTTPRequest
    {

        public PutHTTPRequest(Client client)
        {
            request.Method = "PUT";
        }
    }

    public class DelHTTPRequest : HTTPRequest
    {
        
        public DelHTTPRequest(Client client)
        {
            request.Method = "DELETE";
        }
    }

    public class RequestExecutor : System.Net.WebRequest
    {
       
        public static ExecutionResult executeRequest(HTTPRequest request) 
        {
            System.Net.WebResponse response = request.GetResponse();
            ExecutionResult executionResult = new ExecutionResult(response);
            return executionResult;
        }
    }
    public class ExecutionResult
    {
        public Stream dataStream;
        public String status;
        public String responseFromServer;
        public System.Net.WebResponse response;
        public ExecutionResult(System.Net.WebResponse response)
        {
            this.status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            this.response = response;
            response.Close();
        }
    }
}
