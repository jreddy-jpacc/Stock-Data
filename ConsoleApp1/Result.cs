using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StockData
{
    class Result
    {
        /*
        * Complete the 'findSmallestDivisor' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts following parameters:
        *  1. STRING s
        *  2. STRING t
        */
        public static int counter = 0;
        public static string connected = string.Empty;
        public static int findSmallestDivisor(string s, string t)
        {
            connected = String.Concat(s, t);
            try
            {
                if (s.Contains(t))
                {
                    if (t == s)
                    {
                        Console.WriteLine(1);
                        return 1;
                    }

                    if (t + t == s)
                    {
                        Console.WriteLine(2);
                        return 2;
                    }

                    if (AddString(t))
                    {
                        Console.WriteLine(counter);
                        return counter;
                    }
                    counter = 0;
                    var small = string.Empty;
                    for (int i = 0; i < t.Length; i++)
                    {
                        if (t.Substring(0, i) + t.Substring(0, i) == t)
                        {
                            small = t.Substring(0, i);
                        }
                    }
                    if (small != string.Empty && AddString(small))
                    {
                        Console.WriteLine(counter);
                        return counter;
                    }
                }
                Console.ReadLine();
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public static bool AddString(string s1)
        {
            counter++;
            while (counter < connected.Length)
            {
                if (s1 == connected)
                {
                    return true;
                }
                else
                {
                    return AddString(s1 + s1);
                }
            }
            return false; ;

        }
    }
}
