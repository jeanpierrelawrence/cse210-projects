using System;

class Program
{
    static void Main(string[] args)
    {

        Fraction defaultFraction = new Fraction();
        Fraction wholeNumber = new Fraction(5);
        Fraction custom = new Fraction(6, 7);

        Console.WriteLine(defaultFraction.GetBottom());
        Console.WriteLine(wholeNumber.GetFractionString());

        custom.SetTop(15);
        custom.SetBottom(5);

        Console.WriteLine(custom.GetTop());
        Console.WriteLine(custom.GetDecimalValue());

    }
}