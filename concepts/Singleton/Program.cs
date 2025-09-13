using System;
using Singleton;
class officeBoy
{
    static void main(string[] args)
    {
        officeBoy sweeper, waiter;
        string s1;
        float f1;
        sweeper = officeBoy.GetObject();
        waiter = officeBoy.GetObject();
        sweeper.val = 60;
        Console.WriteLine("sweeper Value :{0}", sweeper.val);
        Console.WriteLine("waiter Value :{0}", waiter.val);
        s1 = sweeper.val.ToString();
        f1 = (float)sweeper.val;
        sweeper.val = int.Parse(s1);
        sweeper.val = Convert.ToInt32(s1);
    }
}
