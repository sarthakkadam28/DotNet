using System;
public class Team : IEnumerable
{
    private player[] players;
    public Team()
    {
        Players = new Player[3];
        Players[0] = new Player("Sachin", 40000);
        Players[1] = new Player("Rahul", 35000);
        Players[2] = new Player("Mahindra", 34000);
    }

    public IEnumertor GetEnumerator()
    {
        Return players.GetEnumerator();
    }
}

class Num {

    public static void Main()
    {
        Team India = new Team();
        foreach (Player c in India)
        {
            Console.WriteLine(c.Name, c.Runs);
        }
    }
}
