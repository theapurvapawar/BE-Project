using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    internal class GetHTTPRequest : HTTPRequest
    {
        internal GetHTTPRequest(Client client)
            : base(client)
        {
            method = "GET";
        }
    }
}
