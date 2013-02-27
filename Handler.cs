using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    public class Handler
    {
        internal Client client;
        internal String path;
        //bool flag = false;
        public Handler(Client client) // Constructor
        {
            this.client = client;
        }

        public void createContainer(String containerName)
        // creates and executes request for Creation of Container
        {
                PutHTTPRequest request = new PutHTTPRequest(this.client);
                path = containerName;
                request.createHTTPRequest(path, Resource1.ContainerRequest);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);
        }

        public void displayAccountContents()
        // Creates and executes request for Listing of Containers.
        {
            GetHTTPRequest request = new GetHTTPRequest(this.client);
            request.createHTTPRequest(Resource1.AccountRequest);
            ExecutionResult executionResult = request.executeRequest();
            Console.WriteLine(executionResult.responseFromServer);
        }

        public void displayContainerContents(String containerName)
        // creates and executes request for listing of contents of container
        {
            try
            {
                path = containerName;
                GetHTTPRequest request = new GetHTTPRequest(this.client);
                request.createHTTPRequest(path, Resource1.ContainerRequest);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);
            }
            catch (ExceptionHandler)
            {
                ExceptionHandler.exceptionDetails(Resource1.NoContainer);
            }
        }

        public void createObject(String containerName, String objectName, String objectValue)
        // creates and executes request for listing of creation of object
        {
            path = containerName + "/" + objectName;
            byte[] buf = Encoding.UTF8.GetBytes("{ \"mimetype\" : \"text/plain\"," +
                "\"value\" : \"" + objectValue + "\"  }");
            PutHTTPRequest request = new PutHTTPRequest(this.client);
            request.createHTTPRequest(path, Resource1.ObjectRequest);
            request.request.GetRequestStream().Write(buf, 0, buf.Length);
            ExecutionResult executionResult = request.executeRequest();
            Console.WriteLine(executionResult.responseFromServer);
        }

        public void deleteContainer(String containerName)
        {
            //delete an existing container
            try
            {
                path = containerName;
                DelHTTPRequest request = new DelHTTPRequest(this.client);
                request.createHTTPRequest(path, Resource1.ContainerRequest);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);
            }
            catch (ExceptionHandler)
            {
                ExceptionHandler.exceptionDetails(Resource1.CantDeleteContainer);
            }
        }

        public void deleteObject(String containerName, String objectName)
        {
            //delete an existing dataobject
            try
            {
                path = containerName + "/" + objectName;
                DelHTTPRequest request = new DelHTTPRequest(this.client);
                request.createHTTPRequest(path, Resource1.ObjectRequest);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);
            }
            catch (ExceptionHandler)
            {
                ExceptionHandler.exceptionDetails(Resource1.CantDeleteObject);
            }
        }

        public void displayObjectContents(String containerName, String objectName)
        {
            //display contents of object
            try
            {
                path = containerName + "/" + objectName;
                GetHTTPRequest request = new GetHTTPRequest(this.client);
                request.createHTTPRequest(path, Resource1.ObjectRequest);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);
            }
            catch (ExceptionHandler)
            {
                ExceptionHandler.exceptionDetails(Resource1.NoObject);
            }
        }

        public Container getContainer(String containerName)
        {
            try
            {
                path = containerName;
                Container container = new Container(client, path);
                return container;
            }
            catch (ExceptionHandler)
            {
                throw;
            }
        }

    }
}
