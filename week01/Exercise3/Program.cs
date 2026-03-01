using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);

        int guess = 0;
        int guessCount = 0;

        while (guess != number)
        {
            Console.Write("Guess a number between 1 - 10: ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (guess > number)
            {
                Console.WriteLine("Lower!");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher!");
            }
        }

        Console.WriteLine($"You guessed right! It took you {guessCount} guesses.");
    }
}