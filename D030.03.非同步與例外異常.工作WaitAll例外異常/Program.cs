﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace D030.非同步與例外異常.工作WaitAll例外異常
{
    class Program
    {
        static List<int> 工作IDs = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static void Main(string[] args)
        {
            Task[] allDelegateTasks = (from 工作ID in 工作IDs select 非同步工作委派方法Async(工作ID)).ToArray();

            Console.WriteLine("主執行緒暫停三秒鐘");
            Thread.Sleep(3000);

            // 因為當執行 WaitAll 屬於 封鎖 Block 模式，因此，在這個範例中，將會拋出例外異常
            // 因此，需要使用 Try...Catch 包起來，這樣程式碼才不會中斷
            Task.WaitAll(allDelegateTasks);

            //var fooIndex = 3;
            //var fooTask = allDelegateTasks[fooIndex];

            //Console.WriteLine($"Status : {fooTask.Status}");
            //Console.WriteLine($"IsCompleted : {fooTask.IsCompleted}");
            //Console.WriteLine($"IsCanceled : {fooTask.IsCanceled}");
            //Console.WriteLine($"IsFaulted : {fooTask.IsFaulted}");
            //var exceptionStatusX = (fooTask.Exception == null) ? "沒有 AggregateException 物件" : "有 AggregateException 物件";
            //Console.WriteLine($"Exception : {exceptionStatusX}");

            Console.WriteLine("按下任一按鍵，結束處理程序");
            Console.ReadKey();
        }

        static async Task 非同步工作委派方法Async(int id)
        {
            await Task.Delay(500 + id * 100);
            Console.WriteLine($"執行工作 {id}");
            if (id % 9 == 4)
            {
                Console.WriteLine($"工作{id} 將要產生例外異常");
                throw new InvalidCastException($"發生異常了，工作ID是{id}");
            }
            if (id % 9 == 6)
            {
                Console.WriteLine($"工作{id} 將要產生例外異常");
                throw new InvalidProgramException($"發生了例外異常，工作ID是{id}");
            }
        }
    }
}
