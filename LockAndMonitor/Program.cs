using System.Diagnostics;
using LockAndMonitor;

public class Program
{
    private readonly static object _locker = new();
    static void Main(string[] args)
    {

        /*Thread first = new(SafeCheckSharedState);
        first.Name = "First";
        Thread second = new(SafeCheckSharedState);
        second.Name = "second";
        
        first.Start();
        second.Start();*/
        /*Account account = new(20000);
        Task task1 = Task.Factory.StartNew(() => account.WithdrawRandomly());
        Task task2 = Task.Factory.StartNew(() => account.WithdrawRandomly());
        Task task3 = Task.Factory.StartNew(() => account.WithdrawRandomly());
        Task.WaitAll(new Task[] { task1, task2, task3 });
        Console.WriteLine("all tasks completed");*/

        Process process = new();
        process.StartInfo.FileName = @"C:\Program Files (x86)\Ketabrah\Ketabrah.exe";
        process.Start();


        void SafeCheckSharedState()
        {
            //lock (_locker)
            Monitor.Enter(_locker);
            try
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                for (int i = 0; i < 100; i++)
                {
                    Console.Write(i);
                }
            }
            finally
            {
                Monitor.Exit(_locker);
            }

            Console.WriteLine($"{Thread.CurrentThread.Name} completed");
        }
    }
}