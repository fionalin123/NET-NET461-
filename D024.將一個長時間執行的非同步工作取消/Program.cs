using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace D024.將一個長時間執行的非同步工作取消
{
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();

        static async Task Main(string[] args)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;

            try
            {
                await MyMethodAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"{Environment.NewLine}下載已經取消");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{Environment.NewLine}發現例外異常 {ex.Message}");
            }
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            cts.Cancel();

            e.Cancel = true;
        }

        static async Task MyMethodAsync(CancellationToken token)
        {
            await Task.Run(() =>
            {
                int cc = 0;
                while(true)
                {
                    //if (token.IsCancellationRequested)
                    //    break;

                    token.ThrowIfCancellationRequested();

                    if (cc++ % 10 == 0) Console.Write(".");
                    Thread.Sleep(100);
                }
            });

        }
    }
}
