using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        private static async Task WaitAsync(string label, int id, int ms)
        {
            Console.WriteLine($"Await async {label} id:{id}");
            await Task.Delay(ms);
        }

        private static async Task WaitNTimesAsync(string label, int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                //await one by one for async function to complete
                //yield to the caller while awaiting
                await WaitAsync(label, i, i * 1000);
            }
        }

        private static async Task WaitAllAsync(string label, int from, int to)
        {
            var taskList = new List<Task>();
            for (int i = from; i <= to; i++)
            {
                //call async function without awaiting
                taskList.Add(WaitAsync(label, i, i * 1000));
            }

            //wait for all tasks (from async function) to complete
            await Task.WhenAll(taskList.ToArray());
        }

        public static void Main()
        {
            var task = WaitNTimesAsync("method1", 5, 9);
            var task2 = WaitNTimesAsync("method2", 5, 9);
            Task.WaitAll(task, task2);

            var task3 = WaitAllAsync("method waitAll", 5, 9);
            task3.Wait();
        }
    }
}