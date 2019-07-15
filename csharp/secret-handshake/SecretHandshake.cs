using System.Linq;

public static class SecretHandshake
{
    private static string[] _actions = 
    {
        "wink",
        "double blink",
        "close your eyes",
        "jump"
    };

    public static string[] Commands(int commandValue)
    {
        var actions = _actions.Where((x, i) => (1 << i & commandValue) > 0);
        return (1 << 4 & commandValue) > 0 ? actions.Reverse().ToArray() : actions.ToArray();   
    }
}
