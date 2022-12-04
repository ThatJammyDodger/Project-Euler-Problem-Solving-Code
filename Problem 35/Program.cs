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

var arr = new List<int>(GetPrimes(1000000));
Console.WriteLine(arr.Count);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);