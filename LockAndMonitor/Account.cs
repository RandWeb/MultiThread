namespace LockAndMonitor;

internal class Account
{
    Object aLock = new();
    int balance;
    Random random = new();

    public Account(int InitialBalance)
    {
        this.balance = InitialBalance;
    }

    int Withdraw(int amount)
    {
        if (balance < 0)
        {
            throw new Exception("not enough balance");
        }

        Monitor.Enter(aLock); // this is where the lock begins
        try
        {
            if (balance >= amount)
            {
                Console.WriteLine("Amount drawn: " + amount);
                balance -= amount;
                return this.balance;
            }
        }
        finally
        {
            Monitor.Exit(aLock); // finish the lock
        }

        return 0;
    }

    public void WithdrawRandomly()
    {
        for (int i = 0; i < 100; i++)
        {
            int balance = Withdraw(random.Next(2000, 5000));
            if (balance > 0)
            {
                Console.WriteLine(Task.CurrentId + " Balance left: " + balance);
            }
        }
    }
}