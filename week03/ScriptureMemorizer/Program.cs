// Instead of a single verse, I added functionality that allowed the program to store a list of different scriptures from which the user could choose.
// I also created a user menu which allows them to choose from the list of scriptures they have.
// I refactored the main logic into specialized static methods (ChooseScripture, GetScripture, RunGame). This demonstrates the principle of Separation of Concerns by isolating the UI, the data factory, and the game loop.
// I added a "Count-Validation Gate" in the HideRandomWords method. This prevents the program from freezing when the number of words left to hide is smaller than the requested hide amount.
// I implemented a factory-style method that transforms raw, delimited strings into fully initialized Reference and Scripture objects, making the system easily expandable.

using System;
using System.Diagnostics.Metrics;

class Program
{
    static void Main(string[] args)
    {

        List<string> scriptures = [
            "John 3:16|For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.",
            "Proverbs 3:5-6|Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.",
            "Philippians 4:13|I can do all things through Christ which strengtheneth me.",
            "Psalm 23:1|The Lord is my shepherd; I shall not want.",
            "Matthew 11:28|Come unto me, all ye that labour and are heavy laden, and I will give you rest.",
            "Romans 8:28|And we know that all things work together for good to them that love God.",
            "Isaiah 40:31|But they that wait upon the Lord shall renew their strength; they shall mount up with wings as eagles."];

        Scripture scriptureToLearn = ChooseScripture(scriptures);

        RunGame(scriptureToLearn);

    }

    public static Scripture ChooseScripture(List<string> scriptures)
    {
        int counter = 0;
        Console.Clear();

        foreach (string option in scriptures)
        {
            string fullReference = option.Split("|")[0];
            counter++;
            Console.WriteLine($"{counter}:     {fullReference}");
        }



        Console.WriteLine("Pick a scripture to learn (1-7): ");
        int selection = int.Parse(Console.ReadLine()) - 1;

        string[] fullScripture = scriptures[selection].Split("|");

        return GetScripture(fullScripture);
    }
    public static Scripture GetScripture(string[] fullScripture)

    {
        string referencePart = fullScripture[0];

        int lastSpaceIndex = referencePart.LastIndexOf(' ');

        string book = referencePart.Substring(0, lastSpaceIndex);

        string numbersPart = referencePart.Substring(lastSpaceIndex + 1);

        char[] numDelimiters = { ':', '-' };
        string[] bits = numbersPart.Split(numDelimiters);

        int chapter = int.Parse(bits[0]);
        int startVerse = int.Parse(bits[1]);

        int endVerse = bits.Length > 2 ? int.Parse(bits[2]) : startVerse;

        Reference reference = new Reference(book, chapter, startVerse, endVerse);
        Scripture scripture = new Scripture(reference, fullScripture[1]);

        return scripture;
    }
    public static void RunGame(Scripture scripture)
    {
        string input = "";

        do
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();


            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            input = Console.ReadLine();

            // 3. Action
            if (input.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }

        } while (input.ToLower() != "quit");
    }
}