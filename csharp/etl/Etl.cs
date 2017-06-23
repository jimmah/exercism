using System;
using System.Collections.Generic;

public static class ETL
{
    public static IDictionary<string, int> Transform(IDictionary<int, IList<string>> old)
    {
        var result = new Dictionary<string, int>();

        foreach (var pair in old)
        {
            foreach (var item in pair.Value)
            {
                result.Add(item.ToLower(), pair.Key);
            }
        }

        return result;
    }
}