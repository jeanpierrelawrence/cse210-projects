

public class Prompt
{
    public List<string> _prompts = [
        "What was the most significant challenge you faced today, and how did you navigate it?",
        "Identify one decision you made today; what were the alternative outcomes?",
        "What is a specific piece of feedback you received recently, and how do you plan to apply it?",
        "What is the most complex concept you learned or practiced today?",
        "If you could optimize one part of your daily routine, what would it be?",
        "List three specific tasks you completed that contributed to your long-term goals.",
        "Describe a social interaction today that shifted your perspective.",
        "What aspect of your current environment is most conducive to your productivity?",
        "What was the most surprising piece of information you encountered today?"
    ];

    private List<string> _usedPrompts = [];

    private Random random = new Random();

    public string Random()
    {

        if (_prompts.Count == 0)
        {
            _prompts.AddRange(_usedPrompts);
            _usedPrompts.Clear();
        }
        int index = random.Next(0, _prompts.Count);
        string _usedPrompt = _prompts[index];

        _usedPrompts.Add(_usedPrompt);
        _prompts.Remove(_usedPrompt);

        return _usedPrompt;
    }
}