using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    class ExceptionHandler:System.Net.WebException
    {
        public ExceptionHandler()
        {
 
        }

        public ExceptionHandler(String message)
            : base(message)
        {
            Console.WriteLine(base.Message);
        }

        public static void exceptionDetails(String message)
        {
            Console.WriteLine(message);
        }

    }
}
