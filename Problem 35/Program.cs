/*  The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

    There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

    How many circular primes are there below one million?  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

int[] GetPrimes(int n)  // gets the primes up to n
{
    List<int> primes = new() { 2 };

    int counter = 3;
    while (counter <= n)
    {
        bool prime = true;
        foreach (var x in primes)
        {
            if (counter % x == 0)
            {
                prime = false;
                break;
            }
        }
        if (prime)
            primes.Add(counter);
        counter += 2;
    }
    return primes.ToArray();
}
List<int> circular_primes = new();

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

string[] GetRotations(string a)
{
    List<string> final = new();
    for (int i = 0; i < a.Length; i++)
    {
        final.Add( a.Substring(i) + a.Substring(0, i) );
    }
    return final.ToArray();
}

/*var arr = new SortedSet<int>(GetPrimes(1000000));

foreach(int i in arr)
{
    var tl = GetRotations(i.ToString());
    foreach(var x in tl)
    {
        arr.Remove(Int32.Parse(x));
    }
}*/


sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);