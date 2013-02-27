using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    internal class RequestUtil
        //Creates URL for CRUD Operations on container & dta objects.
    {
        internal static String formAuthURL(Client client)
        {
            return CommonConstants.HTTP_PREFIX + client.serverIP + ":" + 
                CommonConstants.PORT_NUMBER_CONSTANT + "/" +
                CommonConstants.AUTH_URL_CONSTANT;
        }
        
        internal static String formAccountURL(Client client)
        {
            return CommonConstants.HTTP_PREFIX + client.serverIP + ":" + 
                CommonConstants.PORT_NUMBER_CONSTANT + "/" +
                CommonConstants.CDMI_PATH_CONSTANT + "/" + 
                CommonConstants.ACCOUNT_PREFIX + client.username + "/";
        }

        internal static String formContainerURL(Client client, String path)
        {
            return CommonConstants.HTTP_PREFIX + client.serverIP + ":" + 
                CommonConstants.PORT_NUMBER_CONSTANT + "/" +
                CommonConstants.CDMI_PATH_CONSTANT + "/" + 
                CommonConstants.ACCOUNT_PREFIX + client.username + "/" + path + "/";
        }

        internal static String formObjectURL(Client client, String path)
        {
            return CommonConstants.HTTP_PREFIX + client.serverIP + ":" + 
                CommonConstants.PORT_NUMBER_CONSTANT + "/" +
                CommonConstants.CDMI_PATH_CONSTANT + "/" +
                CommonConstants.ACCOUNT_PREFIX + client.username + "/" +
                path + " ";
        }
    
    }
}
