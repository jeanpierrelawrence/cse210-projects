public class GoalManager
{
    private List<Goal> _goals = [];
    private int _score = 0;
    public void Start()
    {
        string input = "";
        while (input != "6")
        {
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
            }
        }
    }
    public int DisplayPlayerInfo()
    {
        return _score;
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(name, description, points);
                bool wasFinished = bool.Parse(parts[4]);

                if (wasFinished)
                {
                    goal.SetComplete();
                }

                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (type == "ChecklistGoal")
            {
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                goal.SetAmountCompleted(amountCompleted);
                _goals.Add(goal);
            }
        }
    }
    public void SaveGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Please create a goal first!");
            return;
        }

        Console.WriteLine("What would you like your file name to be? (e.g 'my_goals.txt') ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(DisplayPlayerInfo());

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }
    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");

        if (int.TryParse(Console.ReadLine(), out int response))
        {

            if (response > 0 && response <= _goals.Count)
            {
                Goal accomplishedGoal = _goals[response - 1];
                accomplishedGoal.RecordEvent();
                _score += accomplishedGoal.GetPoints();

                Console.WriteLine($"Congratulations! You earned {accomplishedGoal.GetPoints()} points!");
                Console.WriteLine($"Your new score: {DisplayPlayerInfo()}");
            }
            else
            {
                Console.WriteLine("Invalid selection. Number out of range.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int i = 0;

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
        }

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
            i++;
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist of goals");
        Console.Write("Select a choice from the menu: ");

        string input = Console.ReadLine();

        Console.WriteLine("What will the name of this goal be? ");
        string title = Console.ReadLine();

        Console.WriteLine("Describe this goal briefly:\n");
        string description = Console.ReadLine();

        Console.WriteLine("How many points will you win if you complete this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (input)
        {
            case "1":

                SimpleGoal simpleGoal = new SimpleGoal(title, description, points);
                _goals.Add(simpleGoal);

                break;
            case "2":

                EternalGoal eternalGoal = new EternalGoal(title, description, points);
                _goals.Add(eternalGoal);

                break;
            case "3":

                Console.WriteLine("How many times does this goal need to be accomplished before you get bonus points? ");
                int checklistGoalAmount = int.Parse(Console.ReadLine());

                Console.WriteLine("What is the bonus? ");
                int checklistGoalBonusPoints = int.Parse(Console.ReadLine());

                ChecklistGoal checklistGoal = new ChecklistGoal(title, description, points, checklistGoalAmount, checklistGoalBonusPoints);
                _goals.Add(checklistGoal);

                break;

            default:
                Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                break;
        }
    }
}