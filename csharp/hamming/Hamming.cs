public static class Hamming
{
    public static int Compute(string firstStrand, string secondStrand)
    {
        var distance = 0;

        for (var i = 0; i < firstStrand.Length; i++) 
        {
            if (firstStrand[i] != secondStrand[i])
                distance++;
        }

        return distance;
    }
}