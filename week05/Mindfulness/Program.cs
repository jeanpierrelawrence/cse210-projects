/*
  EXCEEDING REQUIREMENTS REPORT:
  1. Implemented 'No-Repeat' logic for Reflecting Activity: Questions and Prompts are tracked 
     in a separate list and removed once used to ensure no duplicates occur in a single session.
  2. Added log history: Every completed activity is automatically logged to 
     'activity_log.txt' with a timestamp.
  3. Added a 'View Log' menu option (Option 4) that reads and displays the history from 
     the text file, demonstrating data loading capabilities.
*/

using System;

class Program
{
    static void Main(string[] args)
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool running = true;
        while (running)
        {
            int choice = RunMenu();

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    new BreathingActivity().Run();
                    break;
                case 2:
                    Console.Clear();
                    new ReflectingActivity().Run();
                    break;
                case 3:
                    Console.Clear();
                    new ListingActivity().Run();
                    break;
                case 4:
                    ViewLog();
                    break;
                case 5:
                    Console.Clear();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
    }

    public static int RunMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. View History");
        Console.WriteLine("5. Quit");
        Console.Write("Select a choice from the menu: ");

        if (int.TryParse(Console.ReadLine(), out int result))
        {
            return result;
        }
        return 0; // Returns 0 for invalid input, triggering the default case
    }
    private static void ViewLog()
    {
        Console.Clear();
        Console.WriteLine("--- Activity History ---");
        if (File.Exists("activity_log.txt"))
        {
            string content = File.ReadAllText("activity_log.txt");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("No activities logged yet.");
        }
        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
    }
}
