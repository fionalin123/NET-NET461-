using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace D008.利用TAP工作建立大量並行工作練習
{
    class Program
    {
        static object __lockObj = new object();

        static async Task Main(string[] args)
        {
            //string URL = "http://mocky.azurewebsites.net/api/delay/2000";

            var list = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var index = string.Format("{0:D2}", (i + 1));

                list.Add(TaskAsync(1, index));
                list.Add(TaskAsync(2, index));

            }

            await Task.WhenAll(list);

        }

        static private async Task TaskAsync(int count, string index)
        {
            string URL = "http://mocky.azurewebsites.net/api/delay/2000";

            // 取得當下的 ThreadId
            var tid = String.Format("{0:D2}", Thread.CurrentThread.ManagedThreadId);

            HttpClient client = new HttpClient();

            ShowDebugInfo(index, count, tid, ">>>>");
            var result = await client.GetStringAsync(URL);
            ShowDebugInfo(index, count, tid, "<<<<", result);


        }


        static void ShowDebugInfo(string index, int trial, string tid, string sep, string result = null)
        {
            lock (__lockObj)
            {
                ConsoleColor orig = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{index}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" << ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{trial}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" >> 測試 (TID: ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{tid}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($")");

                if (result != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Write($" {sep} ");

                if (result != null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                Console.Write($"{DateTime.Now}");

                Console.ForegroundColor = ConsoleColor.Cyan;
                if (result != null)
                {
                    Console.Write($" {result}");
                }
                Console.WriteLine();

                Console.ForegroundColor = orig;
            }
        }
    }
}
