using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace D028.射後不理FireAndForget
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("對於一個非同步工作方法，採用射後不理，將會正常結束 ...");

            OnDelegateAsync();

            Console.WriteLine("Press any key for 了解當非同步工作內拋出例外異常，會如何？");
            Console.ReadKey();

            // 這段程式屬於射後不理寫法，無法進行 try/catch 並且會導致應用程式意外結束！
            OnDelegateWithExceptionAsync();

            Console.WriteLine("按下任一按鍵，結束處理程序");
            Console.ReadKey();
        }

        public static async void OnDelegateAsync()
        {
            Console.WriteLine("OnDelegateAsync 方法開始執行了");
            await Task.Delay(2000);
            Console.WriteLine("OnDelegateAsync 方法結束執行了");
        }

        public static async void OnDelegateWithExceptionAsync()
        {
            // 這樣寫法不好，因該用 try...catch 捕捉例外異常，把捕到的例外異常呼叫 tcs.SetException()

            Console.WriteLine("OnDelegateWithExceptionAsync 開始執行了");
            await Task.Delay(2000);
            throw new Exception("有例外異常發生了");
            Console.WriteLine("OnDelegateWithExceptionAsync 方法結束執行了");
        }
    }
}
