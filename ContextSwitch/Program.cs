public class Program
{
    public static void Main(string[] args)
    {
        // step 1: declare a thread, haven't firing this thread yet
        Thread thread = new Thread(WriteUsingNewThread); // pass in the name of a function

       // step 2: let the thread scheduler know to spawn off this thread
        thread.Start(); // a worker thread starts to work
        thread.Name = "worker thread1"; // give a worker thread a name for easy debugging

        // the following code runs in the main thread
        Thread.CurrentThread.Name = "main thread"; // give current thread, which is the main thread, a name
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(string.Format(" A {0} ", i));
        }
    }

    private static void WriteUsingNewThread()
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(string.Format(" Z {0} ", i));
        }
    }

}