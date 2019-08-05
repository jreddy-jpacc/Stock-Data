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
        public static string substr = string.Empty;
        public static int findSmallestDivisor(string s, string t)
        {
            connected = String.Concat(s, t);
            try
            {
                if (s.Contains(t))
                {
                    if (t.Equals(s))
                    {
                        Console.WriteLine(1);
                        return 1;
                    }

                    if (string.Equals((t + t), s))
                    {
                        Console.WriteLine(2);
                        return 2;
                    }
                    substr = t;
                    if (AddString(t))
                    {
                        Console.WriteLine(counter);
                        return counter;
                    }
                    counter = 0;
                    var small = string.Empty;
                    for (int i = 0; i < t.Length; i++)
                    {
                        if (string.Equals((t.Substring(0, i) + t.Substring(0, i)), t))
                        {
                            small = t.Substring(0, i);
                            substr = small;
                        }
                    }
                    if (small != string.Empty && AddString(small))
                    {
                        Console.WriteLine(counter);
                        return counter;
                    }
                }
                Console.WriteLine(-1);
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public static bool AddString(string s1)
        {
          
            if (s1.Equals(connected))
            {
                return true;
            }
            counter++;
            while (s1.Length < connected.Length)
            {
                return AddString(s1 + substr);
            }
            return false; ;

        }
         public static long teamFormation(List<int> score, int team, int m)
        {
            try
            {
                long finalCount = 0;
                if (team == score.Count)
                {
                    Console.WriteLine(score.Sum());
                    return score.Sum();
                }
                if(score.Count > 0 && team != 0 && m!=0)
                {
                    
                    
                    for(int j=0; j<team;j++)
                    {
                        Dictionary<int, int> first = new Dictionary<int, int>();
                        Dictionary<int, int> second = new Dictionary<int, int>();
                        for (int i = 0; i < m; i++)
                        {
                            first.Add(i, score[i]);
                        }

                        var len = score.Count() - m;

                        for (int i = len; i < score.Count(); i++)
                        {
                            second.Add(i, score[i]);
                        }

                       
                      
                        var valueforfirst = first.Values.Max();
                        var keyforfirst = first.FirstOrDefault(x => x.Value == valueforfirst).Key;

                        var valueforSecond = second.Values.Max();
                        var keyforSecond = second.FirstOrDefault(x => x.Value == valueforSecond).Key;
                       

                        if (valueforfirst >= valueforSecond)
                        {
                            finalCount += valueforfirst;
                            score.RemoveAt(keyforfirst);
                        }
                        else if (valueforfirst <= valueforSecond)
                        {
                            finalCount += valueforSecond;
                            score.RemoveAt(keyforSecond);
                        }
                        
                    }
                   


                }
                return finalCount;


            }
            catch
            {

            }
            return 1;
            
        }
    }
}
