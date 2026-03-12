using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void saveToFile(string fileName)
    {
        string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(fileName, jsonString);
    }

    public void loadFromFile(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);

        _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
    }
}