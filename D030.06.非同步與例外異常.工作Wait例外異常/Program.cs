using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D030.非同步與例外異常.工作Wait例外異常
{
    class Program
    {
        static void Main(string[] args)
        {
            var fooTask = Task.Run(async () =>
            {
                await Task.Delay(500);
                throw new InvalidProgramException($"發生了例外異常");
            });

            fooTask.Wait();

            Console.WriteLine("按下任一按鍵，結束處理程序");
            Console.ReadKey();
        }
    }
}
