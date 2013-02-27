using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    public class Container
    //This class is used to perform CRUD operations on container & it's children.
    {
        internal Client client;
        internal String path;
        String objectName;
        String capabilitiesURI;
        String parentURI;
        String[] children;
        String metadata;
        String objectType;
        String childrenRange;
        int flag = 0;

        public Container(Client client, String path)
        //Constructor
        {
            try
            {
                this.client = client;
                this.path = path;
                getContainerDetails(path);
            }
            catch (ExceptionHandler)
            {
                ExceptionHandler.exceptionDetails(Resource1.NoContainer);
            }
        }

        public bool isGetSuccessful()
        {
            if (childrenRange == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void createChildContainer(String childName)
        //Creates child container under given parent container.
        {
            Container container = this.getChildContainer(childName);
            if (container.isGetSuccessful())
            {
                Console.WriteLine(Resource1.OverwriteContainer);
                if (Console.ReadLine() == "n")
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                PutHTTPRequest request = new PutHTTPRequest(this.client);
                request.createHTTPRequest(path + "/" + childName, Resource1.ContainerRequest);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);

            }
            flag = 0;
        }

        public void createChildObject(String childName, String objectValue)
        //Creates child object under given parent container.
        {
            Object newObject = getChildObject(childName);
            if (newObject.isGetSuccessful())
            {
                Console.WriteLine(Resource1.OverwriteObject);
                if (Console.ReadLine() == "n")
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                byte[] buf = Encoding.UTF8.GetBytes("{ \"mimetype\" : \"text/plain\"," +
                    "\"value\" : \"" + objectValue + "\"  }");
                PutHTTPRequest request = new PutHTTPRequest(this.client);
                request.createHTTPRequest(path + "/" + childName, Resource1.ObjectRequest);
                request.request.GetRequestStream().Write(buf, 0, buf.Length);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);
            }
            flag = 0;
        }

        public void deleteChildContainer(String childName)
        //Deletes child container under given parent container.
        {
            try
            {
                DelHTTPRequest request = new DelHTTPRequest(this.client);
                request.createHTTPRequest(path + "/" + childName, Resource1.ContainerRequest);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);
            }
            catch (ExceptionHandler)
            {
                ExceptionHandler.exceptionDetails(Resource1.NoChild);
            }
        }

        public void deleteChildObject(String childName)
        //Deletes child object under given parent container.
        {
            try
            {
                DelHTTPRequest request = new DelHTTPRequest(this.client);
                request.createHTTPRequest(path + "/" + childName, Resource1.ObjectRequest);
                ExecutionResult executionResult = request.executeRequest();
                Console.WriteLine(executionResult.responseFromServer);
            }
            catch (ExceptionHandler)
            {
                ExceptionHandler.exceptionDetails(Resource1.NoObject);
            }
        }

        public Container getChildContainer(String childName)
        //Create new container.
        {
            Container container = new Container(client, path + "/" + childName);
            return container;
        }

        public void displayContents()
        //Display response.
        {
            getContainerDetails(path);
            Console.WriteLine("\nName: " + objectName);
            Console.WriteLine("Type: " + objectType);
            Console.WriteLine("Capabilities URI: " + capabilitiesURI);
            Console.WriteLine("Parent URI: " + parentURI);
            Console.WriteLine("Children Range: " + childrenRange);
            Console.WriteLine("Metadata: " + metadata);
        }

        public Container getParentContainer()
        // Get path of parent container.
        {
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

        public void getContainerDetails(String path)
        {
            //Retrieve the metadata of the container
            GetHTTPRequest request = new GetHTTPRequest(this.client);
            request.createHTTPRequest(path, Resource1.ContainerRequest);
            ExecutionResult executionResult = request.executeRequest();
            childrenRange = JSONParser.getFieldValue("childrenRange", executionResult.responseFromServer);
            objectName = JSONParser.getFieldValue("objectName", executionResult.responseFromServer);
            capabilitiesURI = JSONParser.getFieldValue("capabilitiesURI", executionResult.responseFromServer);
            parentURI = JSONParser.getFieldValue("parentURI", executionResult.responseFromServer);
            metadata = JSONParser.getFieldValue("metadata", executionResult.responseFromServer);
            objectType = JSONParser.getFieldValue("objectType", executionResult.responseFromServer);
        }

        public Object getChildObject(String objectName)
        {
            //get the child object
            Object childObject = new Object(client, path + "/" + objectName);
            return childObject;
        }

    }
}
