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