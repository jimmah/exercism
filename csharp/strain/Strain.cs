using System;
using System.Collections.Generic;
using System.Linq;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate) =>
        Filter(collection, predicate);

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate) =>
        Filter(collection, x => !predicate(x));    

    private static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Func<T, bool> predicate) =>
        collection.Where(predicate);
}