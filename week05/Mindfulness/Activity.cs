
public class Activity
{
    protected string _name;
    protected string _description;
    protected double _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine($"\n{_description}");
        Console.Write("\nHow long, in seconds, would you like for your session? ");

        _duration = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        ShowSpinner(3);
        Console.WriteLine($"You've completed the {_name} in {_duration} seconds");
        LogActivity();
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> loadingCharacters = ["⣾", "⣽", "⣻", "⢿", "⡿", "⣟", "⣯", "⣷"];

        DateTime endDate = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endDate)
        {
            foreach (string c in loadingCharacters)
            {

                if (DateTime.Now >= endDate)
                {
                    break;
                }

                Console.Write(c);
                Thread.Sleep(50);
                Console.Write("\b \b");
            }
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string currentNum = i.ToString();
            Console.Write(currentNum);
            Thread.Sleep(1000);

            int len = currentNum.Length;

            for (int j = 0; j < len; j++)
            {
                Console.Write("\b");
            }

            for (int j = 0; j < len; j++)
            {
                Console.Write(" ");
            }

            for (int j = 0; j < len; j++)
            {
                Console.Write("\b");
            }
        }
    }
    private void LogActivity()
    {
        string logEntry = $"{DateTime.Now}: Completed {_name} for {_duration} seconds.";

        File.AppendAllText("activity_log.txt", logEntry + Environment.NewLine);
    }

}