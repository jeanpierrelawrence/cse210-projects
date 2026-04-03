public class ListingActivity : Activity
{
    private int _count;
    private Random _random = new Random();
    private List<string> _prompts = ["Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"];
    public ListingActivity() : base("ListingActivity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {

    }

    public void Run()
    {
        DisplayStartingMessage();


        Console.WriteLine("List as many responses you can to the following prompt:");
        GetRandomPrompt();
        Console.Write("You may begin in: \n");
        ShowCountdown(5);
        Console.WriteLine();

        List<string> responses = GetListFromUser();
        _count = responses.Count;

        Console.Clear();
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);

        Console.WriteLine($"\n --- {_prompts[index]} ---");
    }

    private List<string> GetListFromUser()
    {
        List<string> inputs = new List<string>();
        DateTime endDate = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endDate)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                inputs.Add(input);
            }
        }

        return inputs;
    }

}