using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else if (grade < 60)
        {
            letter = "F";
        }

        string symbol = "";
        int lastDigit = grade % 10;

        if (lastDigit >= 7)
        {
            symbol = "+";
        }
        else if (lastDigit < 3)
        {
            symbol = "-";
        }

        if (letter == "A" && symbol == "+")
        {
            symbol = "";
        }
        if (letter == "F")
        {
            symbol = "";
        }

        Console.WriteLine($"You got a {letter}{symbol}");

        if (grade >= 70)
        {
            Console.WriteLine("You passed! Congradulations!");
        }
        else
        {
            Console.WriteLine("You didn't pass. Retake the course and sign up for free tutoring.");
        }
    }
}