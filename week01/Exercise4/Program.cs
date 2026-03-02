using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        List<int> numbers = new List<int>();

        while (number != 0)
        {
            numbers.Add(number);

            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
        }

        int total = numbers.Sum();
        double average = numbers.Average();
        int biggestNumber = numbers.Max();

        Console.WriteLine($"The sum of the numbers in your list is: {total}");
        Console.WriteLine($"The average of the numbers in your list is: {average}");
        Console.WriteLine($"The largest number in your list is: {biggestNumber}");

        int minPositive = numbers.Max();

        foreach (int num in numbers)
        {
            if (num > 0)
            {
                if (num < minPositive)
                {
                    minPositive = num;
                }
            }
        }

        Console.WriteLine($"The smallest positive number is: {minPositive}");

        numbers.Sort();

        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}