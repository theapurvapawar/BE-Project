using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    public class Client
    /*This class is used as wrapper for underlying structure & 
    does basic authentication, handler functions.*/
    {
        internal String username, groupname, password, serverIP, token;

        public Client(String serverIP, String username, String groupname,
            String password)
        //Constructor used to initialize data members of class.
        {
            this.serverIP = serverIP;
            this.username = username;
            this.groupname = groupname;
            this.password = password;
        }

        public Boolean getAuthorizationToken()
        //get the Auth Token from Server which can be used for any operation later.
        {
            GetHTTPRequest request = new GetHTTPRequest(this);
            request.createHTTPRequest(Resource1.AuthRequest);
            ExecutionResult executionResult = request.executeRequest();
            token = executionResult.response.Headers
                [CommonConstants.X_AUTH_TOKEN_CONSTANT];
            Console.WriteLine(token);
            if (token != null)
                return true;
            else
                return false;
        }

        public Handler getHandler()//returns Handler
        {
            return new Handler(this);
        }

    }
}
