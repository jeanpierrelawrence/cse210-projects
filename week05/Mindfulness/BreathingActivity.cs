public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endDate = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endDate)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountdown(5);

            if (DateTime.Now >= endDate)
            {
                break;
            }

            Console.WriteLine("\nBreathe out...");
            ShowCountdown(3);
        }

        Console.Clear();

        DisplayEndingMessage();
    }
}