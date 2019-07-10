using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit) => DeterminePrimes(limit).ToArray();

    private static IEnumerable<int> DeterminePrimes(int limit)
    {
        if (limit < 2)
            throw new ArgumentOutOfRangeException(nameof(limit));

        var candidates = Enumerable.Range(2, limit - 1);
        while (candidates.Any()) 
        {
            var prime = candidates.First();
            candidates = candidates.Where(x => x % prime != 0);

            yield return prime;
        }
    }
}