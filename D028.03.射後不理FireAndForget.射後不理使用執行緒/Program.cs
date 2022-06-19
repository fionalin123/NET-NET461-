using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace D028.射後不理FireAndForget.射後不理使用執行續
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("利用執行緒集區取得執行緒，將會正常結束 ...");
            ThreadPool.QueueUserWorkItem(OnDelegate);

            Console.WriteLine("Press any key to continue 利用執行緒集區取得執行緒，將會在委派方法內拋出例外異常 ...");
            Console.ReadKey();
            ThreadPool.QueueUserWorkItem(OnDelegateWithException);

            Console.WriteLine("按下任一按鍵，結束處理程序");
            Console.ReadKey();
        }

        static void OnDelegate(object state)
        {
            Thread.Sleep(5000);
            Console.WriteLine("OnDelegate 方法結束執行了");
        }

        static void OnDelegateWithException(object state)
        {
            Thread.Sleep(5000);
            throw new Exception("有例外異常發生了");
        }
    }
}
