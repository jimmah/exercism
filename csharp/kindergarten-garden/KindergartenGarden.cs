using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private readonly string _diagram;

    private readonly List<string> _students = new List<string>
    {
        "Alice",
        "Bob",
        "Charlie",
        "David",
        "Eve",
        "Fred",
        "Ginny",
        "Harriet",
        "Ileana",
        "Joseph",
        "Kincaid",
        "Larry"
    };

    private static readonly IDictionary<char, Plant> _plants = new Dictionary<char, Plant>
    {
        {'V', Plant.Violets},
        {'R', Plant.Radishes},
        {'C', Plant.Clover},
        {'G', Plant.Grass}
    };

    public KindergartenGarden(string diagram)
    {
        _diagram = diagram;
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var index = _students.IndexOf(student) * 2;

        return _diagram.Split('\n')
                       .SelectMany(l => Enumerable.Range(index, 2), (line, i) => _plants[line[i]]);
    }
}