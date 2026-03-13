/* CREATIVITY AND EXCEEDING REQUIREMENTS:
1. Implemented JSON serialization/deserialization for more robust data storage, 
   handling special characters and commas automatically.
2. Created an advanced Prompt management system that tracks used prompts 
   to ensure the user sees every prompt once before any repeats occur.
3. Added a custom user flow allowing users to choose between a random prompt 
   or a free-form entry ("What's on your mind?").
4. Implemented conditional display logic so the "Prompt" header is hidden 
   if the entry was free-form.
5. Added filename validation using ternary operators to ensure the .json 
   extension is always applied.
*/

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        Prompt _prompt = new Prompt();
        Journal _journal = new Journal();

        Console.WriteLine("Welcome to your journal!");
        DisplayMenu();

        string response = Console.ReadLine();

        while (response != "5")
        {
            if (response == "1")
            {
                Entry _entry = new Entry();

                Console.WriteLine("Would you like a prompt? (y/n) ");
                string wantsPrompt = Console.ReadLine().ToLower();

                if (wantsPrompt == "y")
                {
                    string _promptText = _prompt.Random();
                    Console.WriteLine(_promptText);
                    string userResponse = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(userResponse))
                    {
                        _entry._promptText = _promptText;
                        _entry._entry = userResponse;
                        _journal.AddEntry(_entry);
                        Console.WriteLine("Entry recorded.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Cannot save an empty entry.");
                    }
                }
                else
                {
                    Console.WriteLine("What's on your mind? ");
                    string userResponse = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(userResponse))
                    {
                        _entry._entry = userResponse;
                        _journal.AddEntry(_entry);
                        Console.WriteLine("Entry recorded.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Cannot save an empty entry.");
                    }
                }


            }
            else if (response == "2")
            {
                if (_journal._entries.Count > 0)
                {
                    _journal.DisplayAll();
                }
                else
                {
                    Console.WriteLine("You have no saved entries in your journal!");
                }
            }
            else if (response == "3")
            {
                if (_journal._entries.Count > 0)
                {
                    Console.WriteLine("Choose a file name: ");
                    string fileName = Console.ReadLine();

                    if (!fileName.EndsWith(".json"))
                    {
                        fileName += ".json";
                        _journal.saveToFile(fileName);
                    }
                    Console.WriteLine($"You have successfully created a file named '{fileName}'");

                }
                else
                {
                    Console.WriteLine("You have no entries saved. Create a new entry");
                }
            }
            else if (response == "4")
            {
                Console.Write("What is the filename? ");
                string input = Console.ReadLine();

                string fileName = input.EndsWith(".json") ? input : $"{input}.json";

                if (File.Exists(fileName))
                {
                    FileInfo info = new FileInfo(fileName);

                    if (info.Length > 0)
                    {
                        _journal.loadFromFile(fileName);
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error: The file is empty.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: That file does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Oops, something went wrong!");
            }

            Console.WriteLine();
            DisplayMenu();
            response = Console.ReadLine();
        }

    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following options:");
        Console.WriteLine("1: Create");
        Console.WriteLine("2: Display");
        Console.WriteLine("3: Save");
        Console.WriteLine("4: Load");
        Console.WriteLine("5: Quit");
    }
}