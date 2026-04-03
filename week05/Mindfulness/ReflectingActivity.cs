public class ReflectingActivity : Activity
{
    private Random _random = new Random();
    private List<string> _prompts = ["Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."];
    private List<string> _questions = ["Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different?", "What is your favorite thing about this experience?", "What did you learn about yourself?", "How can you keep this experience in mind?"];
    private List<string> _unusedQuestions = new List<string>();

    public ReflectingActivity() : base("Reflection Activity", "This activity will help you reflect on times of strength.")
    {
        _unusedQuestions = [.. _questions];
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();

        DateTime endDate = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endDate)
        {
            DisplayQuestions();
            ShowSpinner(10);
        }

        Console.Clear();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = [.. _questions];
        }

        int index = _random.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);

        return question;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n --- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
    }

    private void DisplayQuestions()
    {
        Console.Write($"\n> {GetRandomQuestion()} ");
    }
}