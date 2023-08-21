public class Program
{
    static int j = 0;
    static void Main(string[] args)
    {
        /*new Thread(Print1To30).Start();
        Print1To30();*/
        new Thread(Print1To10).Start();
        new Thread(Print1To10).Start();
        
        void Print1To10()
        {
            
            int counter = 10;
            for (int i = 0; j < counter; j++)
            {
                Console.Write(j);
            }
        }
    }

    private static void Print1To30()
    {
        for(int i = 1; i < 31; i++) // i is local variable, which will be only accessed by its own thread.
        {
            Console.Write(i + " ");
        }
    }

  
}