using System;

// Step 1: Declare a delegate type
public delegate void NotifyEventHandler(string message);

// Step 2: Declare a class with an event
public class Publisher
{
    public event NotifyEventHandler OnChange;

    public void DoSomething()
    {
        // Step 3: Raise the event
        OnChange?.Invoke("Event occurred!");
    }
}

class Program
{
    static void Handler(string message)
    {
        Console.WriteLine(message);
    }

    static void Main()
    {
        Publisher pub = new Publisher();
        pub.OnChange += Handler; // Subscribe to the event

        pub.DoSomething(); // Fires the event, calls Handler
    }
}
