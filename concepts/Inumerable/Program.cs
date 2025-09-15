using System;
using System.Collections;
public class Player
{
   public string Name { get; set; }
    public int Runs { get; set; }

    public Player(string name, int runs)
    {
        Name = name;
        Runs = runs;
    }
}
public class Team : IEnumerable
{
    private Player[] players;
    public Team()
    {
        players = new Player[3];
        players[0] = new Player("Sachin", 40000);
        players[1] = new Player("Rahul", 35000);
        players[2] = new Player("Mahindra", 34000);
    }

    public IEnumerator GetEnumerator()
    {
        return players.GetEnumerator();
    }
 }

class Num {

    public static void Main()
    {
        Team India = new Team();
        foreach (Player c in India)
        {
            Console.WriteLine($"{c.Name},{c.Runs}");
        }
    }
}
