
using System;
using Index;
class Program
{
     static void Main(string[] args)
    {
        Books mybook = new Books(); //mybook la direct authority milate ki array use karycha nahi tr aplayla mybook.karun 
                                    // tychi method call karvi lagela
        mybook[3] = "mahabharat";
        mybook[4] = "sepiens";

        Console.WriteLine(mybook[3]);
        Console.WriteLine(mybook[4]); 
    }
    
}

