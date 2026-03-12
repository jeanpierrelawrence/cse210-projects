public class Entry
{
    public string _date { get; set; } = DateTime.Now.ToShortDateString();

    public string _promptText { get; set; } = "";

    public string _entry { get; set; } = "";

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Date: {_date}");

        if (!string.IsNullOrWhiteSpace(_promptText))
        {
            Console.WriteLine($"Prompt: {_promptText}");
        }

        Console.WriteLine();
        Console.WriteLine(_entry);
        Console.WriteLine("---------------------------");
    }
}