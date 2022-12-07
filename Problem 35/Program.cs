/*  The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

    There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

    How many circular primes are there below one million?  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

int[] GetPrimes(int upperLimit)  // gets the primes up to limit
{
    int sieveBound = (int)(upperLimit - 1) / 2;
    int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;
    List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
    bool[] PrimeBits = new bool[sieveBound + 1];
    numbers.Add(2);
    for (int i = 1; i <= upperSqrt; i++)
    {
        if (!PrimeBits[i])
        {
            int inc = 2 * i + 1;
            for (int j = i * 2 * (i + 1); j <= sieveBound; j += inc)
            {
                PrimeBits[j] = true;
            }
            numbers.Add(inc);
        }
    }
    for (int i = upperSqrt + 1; i <= sieveBound; i++)
    {
        if (!PrimeBits[i])
        {
            numbers.Add(2 * i + 1);
        }
    }
    return numbers.ToArray();
}

SortedSet<int> circular_primes = new();

string[] GetRotations(string a)
{
    List<string> final = new();
    for (int i = 0; i < a.Length; i++)
    {
        final.Add( a.Substring(i) + a.Substring(0, i) );
    }
    return final.ToArray();
}

var arr = new SortedSet<int>(GetPrimes(1000000));

foreach(int i in arr)
{
    var tl = GetRotations(i.ToString());
    bool all = true;
    foreach(var x in tl)
    {
        if (!arr.Contains(Int32.Parse(x)))
        {
            all = false;
        }
    }
    if (all)
    {
        foreach (var x in tl)
        {
            circular_primes.Add(Int32.Parse(x));
        }
    }
}

Console.WriteLine("There are {0} circular primes below one million.",circular_primes.Count);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);



/*
string[] GetPermutations(string input)  // recursion algorithm to get all permutations of a given string
{
    List<string> final = new();
    if (input.Length == 0) return final.ToArray();  // basic input handling
    if (input.Length == 1) final.Add(input);
    if (input.Length > 1)
    {
        string part1 = input[0].ToString();  // removes the swapped out character and stores
        string part2 = input.Substring(1);  // stores rest of string
        var p2_pms = GetPermutations(part2);  // recursion bit
        foreach (string x in p2_pms)  // loop adds all permutations of that recursion to the output list
        {
            for (int b = 0; b <= part2.Length; b++)
            {
                string permuted = x.Substring(0, b) + part1 + x.Substring(b);
                final.Add(permuted);
            }
        }
    }
    return final.Distinct().ToArray();  // returns all distinct permutations
}
*/