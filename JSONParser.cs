using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    class JSONParser
    {
        public static String getFieldValue(String fieldName,String JSONString)
        {
            List<String> store = new List<string>();
            Dictionary<String, String> ParsedJSON = new Dictionary<String, String>();
            Dictionary<String, String> s1 = new Dictionary<String, String>();
            Boolean Flag = false;
            int i;
            StringBuilder temp = new StringBuilder();
            JSONString = JSONString.Remove(JSONString.Length-1);
            JSONString = JSONString.Substring(1);
            foreach (char c in JSONString)
            {

                if (c != ',')
                {
                    if (c == '[')
                        Flag = true;
                    else if (c == ']')
                        Flag = false;
                    else if (c != '"' & c != ' ' & c!='\n')
                        temp.Append(c);
                }
                else
                {
                    if (Flag == false)
                    {
                        store.Add(temp.ToString());
                        temp.Clear();
                    }
                }
            }

            store.Add(temp.ToString());
            temp.Clear();
            foreach (String s in store)
            {

                i = s.IndexOf(':');
                temp.Append(s.Substring(i + 1));
                ParsedJSON.Add(s.Remove(i), temp.ToString());
                temp.Clear();

            }
            foreach (KeyValuePair<String, String> entry in ParsedJSON)
            {
                //Console.WriteLine(entry.Key + ":" + entry.Value);
                if (entry.Key.Equals(fieldName))
                    return entry.Value;
            }
            return null;
        }
    }
}
