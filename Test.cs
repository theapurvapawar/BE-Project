using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    class Test
    {
        public static int Main(String[] args)
        {
            Client client = new Client("192.168.1.150", "admin", "admin", "admin");
            if (client.getAuthorizationToken())
            {
                Handler handler = client.getHandler();
                handler.displayAccountContents();
                /*handler.createContainer("MyNewContainer");
                handler.displayAccountContents();
                handler.createObject("MyNewContainer","MyNewObject","TrialObject");
                handler.displayContainerContents("MyNewContainer");
                handler.displayObjectContents("MyNewContainer","MyNewObject");
                handler.deleteObject("MyNewContainer","MyNewObject");
                handler.displayContainerContents("MyNewContainer");
                handler.deleteContainer("MyNewContainer");
                handler.displayAccountContents*/

                handler.createContainer("MyNewContainer");
                Container container = handler.getContainer("MyNewContainer");
                if (!container.isGetSuccessful())
                {
                    Console.WriteLine("Get unsuccessful.....Terminating...");
                    return 0;
                }
                container.createChildContainer("ChildContainer");
                container.displayContents();
                /*container = container.getChildContainer("ChildContainer");
                if (!container.isGetSuccessful())
                {
                    Console.WriteLine("Get Unsuccessful...Terminating...");
                    return 0;
                }
                container.createChildObject("ChildDataObject", "asdasdasdad");
                container.displayContents();
                Object childObject = container.getChildObject("ChildDataObject");
                if (!childObject.isGetSuccessful())
                {
                    Console.WriteLine("Get unsuccessful....Terminating..");
                    return 0;
                }
                childObject.displayContents();
                container = childObject.getParentContainer();
                container.deleteChildObject("ChildDataObject");
                container.displayContents();
                container = container.getParentContainer();
                container.deleteChildContainer("ChildContainer");
                container.displayContents();
                handler.deleteContainer("MyNewContainer");*/
                return 0;
            }
            else
            {
                Console.WriteLine("Unauthorized user");
                return 0;
            }
        }
    }
}
