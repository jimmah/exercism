using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Tournament
{   
    private readonly Dictionary<string, Team> _teams = new Dictionary<string, Team>();

    public Tournament() {}

    public static void Tally(Stream inStream, Stream outStream)
    {
        var tournament = new Tournament();
        var encoding = new UTF8Encoding();
        var reader = new StreamReader(inStream, encoding);

        for (var line = reader.ReadLine(); line != null; line = reader.ReadLine()) 
        {
            var parts = line.Trim().Split(';');
            if (parts.Length != 3)
                continue;

            var result = parts[2].ToEnum<Result>();
            if (!result.HasValue)
                continue;

            tournament.AddResult(parts[0], parts[1], result.Value);
        }

        var writer = new StreamWriter(outStream, encoding)
        {
            NewLine = "\n"
        };

        tournament.Write(writer);
    }

    private void AddResult(string team1, string team2, Result result) 
    {
        AddResult(team1, result);
        AddResult(team2, result == Result.Win ? Result.Loss :
            result == Result.Loss ? Result.Win :
            Result.Draw);
    }

    private void AddResult(string teamName, Result result) 
    {
        if (_teams.TryGetValue(teamName, out var team))
        {
            team.AddResult(result);
        }
        else 
        {
            team = new Team();
            team.AddResult(result);
            _teams.Add(teamName, team);
        }
    }

    private void Write(TextWriter writer) 
    {
        const string format = "{0,-30:S} | {1,2:D} | {2,2:D} | {3,2:D} | {4,2:D} | {5,2:D}{6}";

        writer.Write(format, "Team", "MP", "W", "D", "L", "P", _teams.Count > 0 ? "\n" : "");

        var rows = _teams.OrderByDescending(x => x.Value.Score)
                         .ThenBy(x => x.Key)
                         .ToArray();

        for (var i = 0; i < rows.Length; i++)
        {
            var row = rows[i];

            writer.Write(format, row.Key, row.Value.Played, row.Value.Wins, row.Value.Draws, 
                row.Value.Losses, row.Value.Score, i == rows.Length - 1 ? "" : "\n");
        }

        writer.Flush();
    }
}

public enum Result
{
    Loss,
    Draw,
    Win
}

public class Team
{
    public uint Losses { get; private set; }
    
    public uint Draws { get; private set; }

    public uint Wins { get; private set; }

    public uint Played 
    {
        get => Losses + Draws + Wins;
    }

    public uint Score 
    {
        get => Wins * 3 + Draws;
    }

    public void AddResult(Result result)
    {
        switch (result) 
        {
            case Result.Loss:
                Losses++;
                break;
            case Result.Draw:
                Draws++;
                break;
            case Result.Win:
                Wins++;
                break;
        }
    }
}

public static class EnumExtensions
{
    public static T? ToEnum<T>(this string value) where T : struct
    {
        if (Enum.TryParse<T>(value, true, out var result))
            return result;

        return null;
    }
}
