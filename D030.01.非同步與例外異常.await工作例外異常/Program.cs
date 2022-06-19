using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D030.非同步與例外異常.await工作例外異常
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var fooTask = Task.Run(async () =>
            {
                await Task.Delay(500);
                throw new InvalidProgramException("發生了例外異常");
            });

            //try
            //{
            await fooTask;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"發現例外異常，此例外異常型別為 : {ex.GetType().Name}");
            //}

            Console.WriteLine("按下任一按鍵，結束處理程序");
            Console.ReadKey();
        }
    }
}
