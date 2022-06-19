using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace D020.將AMP改成TAP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 這個網址服務將會回傳 "Delay 1000ms" 並會延遲 1 秒鐘
            string URL = "http://mocky.azurewebsites.net/api/delay/1000";

            WebRequest myHttpWebRequest1 = WebRequest.Create(URL);

            WebResponse webResponse = await Task.Factory.FromAsync(myHttpWebRequest1.BeginGetResponse, myHttpWebRequest1.EndGetResponse, null);

            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                string result = await reader.ReadToEndAsync();
                Console.WriteLine($"網頁執行結果:{result}");
            }
        }
    }
}
