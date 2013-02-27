using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    internal class DelHTTPRequest : HTTPRequest
    {
        internal DelHTTPRequest(Client client)
            : base(client)
        {
            method = "DELETE";
        }
    }
}
