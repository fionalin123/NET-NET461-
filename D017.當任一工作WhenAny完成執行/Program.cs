using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace D017.當任一工作WhenAny完成執行
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task<int>[] tasks = new Task<int>[3];

            Console.WriteLine($"開始執行三個非同步工作:{DateTime.Now}");

            #region 建立與執行三個非同步工作

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("3");
                return 3;
            }
            );

            #endregion 建立與執行三個非同步工作

            // 檢查是否還有未完成的工作
            while (tasks.Length > 0)
            {
                // 取得已經完成的工作物件索引值
                Console.WriteLine($"呼叫 Task.WaitAny 前的執行緒 : {Thread.CurrentThread.ManagedThreadId}");
                Task<int> task = await Task.WhenAny(tasks);
                Console.WriteLine($"呼叫 Task.WaitAny 後的執行緒 : {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"    執行結果 {DateTime.Now} :{task.Result}");
                var temp = tasks.ToList();
                temp.Remove(task);  // 將已經完成的工作，從清單中移除
                tasks = temp.ToArray();
            }

            Console.WriteLine($"結束執行三個非同步工作:{DateTime.Now}");
        }
    }
}
