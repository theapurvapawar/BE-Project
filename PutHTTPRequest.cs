using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    internal class PutHTTPRequest : HTTPRequest
    {
        internal PutHTTPRequest(Client client)
            : base(client)
        {
            method = "PUT";
        }
    }

}
