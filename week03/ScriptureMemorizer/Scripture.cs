class Scripture
{
    private Reference _reference;
    private List<Word> _words = [];

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] scriptureList = text.Split(" ");

        foreach (string wordText in scriptureList)
        {
            Word newWordObject = new Word(wordText);

            _words.Add(newWordObject);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // 1. Calculate how many words are actually available to hide
        int visibleCount = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) visibleCount++;
        }

        if (numberToHide > visibleCount)
        {
            numberToHide = visibleCount;
        }

        int counter = 0;
        Random random = new Random();

        while (counter < numberToHide)
        {
            int index = random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                counter++;
            }
        }
    }

    public string GetDisplayText()
    {
        string reference = _reference.GetDisplayText();

        List<string> bucket = [];

        foreach (Word word in _words)
        {
            bucket.Add(word.GetDisplayText());
        }

        string scripture = string.Join(" ", bucket);

        return $"{reference} {scripture}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}