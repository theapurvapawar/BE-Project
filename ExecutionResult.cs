using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace ObjectStore
{
    internal class ExecutionResult
    {
        Stream dataStream;
        String status;
        internal String responseFromServer;
        internal System.Net.WebResponse response;

        internal ExecutionResult(System.Net.WebResponse response)
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
