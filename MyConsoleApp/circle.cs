
using System;
public abstract class Shape
{
    public abstract double GetArea(); // abstract method

    public void Display()
    {
        Console.WriteLine("This is a shape");
    }
}

// Derived class
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}