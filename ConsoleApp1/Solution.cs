using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockData
{

    class Solution
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string t = Console.ReadLine();

            int result = Result.findSmallestDivisor(s, t);

            Console.WriteLine(result);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();



            //    string _firstDate;
            //    _firstDate = Console.ReadLine();

            //    string _lastDate;
            //    _lastDate = Console.ReadLine();
            //    openAndClosePrices(_firstDate, _lastDate);

        }

        static void openAndClosePrices(string firstDate, string lastDate)
        {
            try
            {
                List<Response> responses = new List<Response>();
                List<data> dataList = new List<data>();
                Response resp = new Response();
                resp = GetData("https://jsonmock.hackerrank.com/api/", "stocks");
                if (resp != null)
                {
                    responses.Add(resp);

                    for (int i = 2; i <= resp.total_pages; i++)
                    {
                        responses.Add(GetData("https://jsonmock.hackerrank.com/api/stocks/", "?page=" + i));
                    }
                }

                foreach (var item in responses)
                {
                    foreach (var dt in item.data)
                    {
                        dataList.Add(dt);
                    }
                }

                var filteredDataList = (from dt in dataList where dt.date >= Convert.ToDateTime(firstDate) && dt.date <= Convert.ToDateTime(lastDate) select dt);

                foreach (var item in filteredDataList)
                {
                    Console.WriteLine(item.date + "   " + item.open + "  " + item.close);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Exceptoin Occured: {0}", ex.Message);
            }

            Console.ReadLine();
        }


        public static Response GetData(string baseAddr, string method)
        {
            Response response = new Response();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddr);
                var responseTask = client.GetAsync(method);
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<Response>(readTask.Result);
                }
            }
            return response;
        }

    }
}

