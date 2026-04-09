public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }
    public override void RecordEvent()
    {
        _amountCompleted++;
    }
    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }

        return false;
    }
    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} | Completed {_amountCompleted}/{_target} times";
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_bonus}|{_target}|{_amountCompleted}";
    }
    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
    public override int GetPoints()
    {
        if (_amountCompleted >= _target)
        {
            return _points + _bonus;
        }

        return _points;
    }
}