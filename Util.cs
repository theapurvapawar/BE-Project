using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    public class Util
    {
        public static String formAuthURL(Client client)
        {
            return CommonConstants.HTTP_PREFIX + client.serverIP + ":" + CommonConstants.PORT_NUMBER_CONSTANT + "/" + CommonConstants.AUTH_URL_CONSTANT;
        }
       
 
    }
    public class CommonConstants
    {
        public static String CDMI_CONTAINER_CONSTANT="application/cdmi-container";
        public static String CONTENT_LENGTH="Content-Length";
        public static String CONTENT_TYPE="Content-Type";
        public static String HTTP_PREFIX="http://";
        public static String X_CDMI_VERSION_CONSTANT="X-CDMI-Specification-Version";
        public static String X_CDMI_VERSION_VALUE_CONSTANT="1.0.1";
        public static String CDMI_OBJECT_CONSTANT = "application/cdmi-object";
        public static String X_STORAGE_USER_CONSTANT = "X-Storage-User";
        public static String X_STORAGE_PASS_CONSTANT = "X-Storage-Pass";
        public static String X_AUTH_TOKEN_CONSTANT = "X-Auth-Token";
        public static String PORT_NUMBER_CONSTANT = "8080";
        public static String AUTH_URL_CONSTANT = "auth/v1.0/";
        public static String CDMI_PATH_CONSTANT = "cdmi";
        public CommonConstants()
        {
        }
    }
}
