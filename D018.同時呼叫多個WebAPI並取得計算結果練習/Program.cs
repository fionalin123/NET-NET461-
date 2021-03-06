using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace D018.同時呼叫多個WebAPI並取得計算結果練習
{
    class Program
    {
        static List<string> 工作IDs = new List<string>()
        {
            "http://mocky.azurewebsites.net/api/delay/1000",
            "http://mocky.azurewebsites.net/api/delay/2000",
            "http://mocky.azurewebsites.net/api/delay/3000"

        };
        static async Task Main(string[] args)
        {
            Task<int>[] allTasks =
                (from 工作ID in 工作IDs
                 select 非同步工作委派方法Async(工作ID)).ToArray();

            Console.WriteLine($"開始執行三個非同步工作:{DateTime.Now}");
            try
            {
                int[] tasked = await Task.WhenAll(allTasks);

                int sum = 0;
                foreach (var item in tasked)
                {
                    sum += item;
                }

                Console.WriteLine($"計算總合為 {sum}");
            }
            catch
            {
                // 當所有等候工作都執行結束後，可以檢查是否有執行失敗的工作
                foreach (Task faulted in allTasks.Where(t => t.IsFaulted))
                {
                    Console.WriteLine(faulted.Exception.InnerException.Message);
                }
            }
            Console.WriteLine($"結束執行三個非同步工作:{DateTime.Now}");

            Console.WriteLine("按下任一按鍵，結束處理程序");
            Console.ReadKey();
        }

        static async Task<int> 非同步工作委派方法Async(string url)
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            return Convert.ToInt32(Regex.Replace(result, "\\D", ""));
        }
    }
}
