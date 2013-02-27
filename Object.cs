using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    public class Object
    {
        //Defines a data object
        String metadata;
        internal Client client;
        internal String path;

        public Object(Client client, String path)
        {
            //constructor
            try
            {
                this.client = client;
                this.path = path;
                this.metadata = getMetadata();
            }
            catch (ExceptionHandler)
            {
                ExceptionHandler.exceptionDetails(Resource1.NoObject);
            }
        }

        public bool isGetSuccessful()
        {
            if (metadata == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void displayContents()
        {
            //display contents of object
            Console.WriteLine(metadata);
        }

        public Container getParentContainer()
        {
            //get parent container of current object
            String parentPath = path;
            int pathLength = parentPath.Length;
            for (int counter = pathLength - 1; counter >= 0; counter--)
            {

                if (parentPath[counter] == '/')
                {
                    parentPath = parentPath.TrimEnd(parentPath[counter]);
                    break;
                }
                parentPath = parentPath.TrimEnd(parentPath[counter]);
            }
            Container container = new Container(client, parentPath);
            return container;
        }

        public String getMetadata()
        {
            //get metadata of the object
            GetHTTPRequest request = new GetHTTPRequest(this.client);
            request.createHTTPRequest(path, Resource1.ObjectRequest);
            ExecutionResult executionResult = request.executeRequest();
            return executionResult.responseFromServer;
        }
    }
}
