using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    internal class RequestExecutor : System.Net.WebRequest
        //Executes request and returns result.
    {
        internal static ExecutionResult executeRequest(HTTPRequest request) 
        {
            try
            {
                System.Net.WebResponse response = request.GetResponse();
                ExecutionResult executionResult = new ExecutionResult(response);
                return executionResult;
            }
            catch(ExceptionHandler)
            {
                //Console.WriteLine(web.ToString());
                throw; 
            } 
        }

    }
}
