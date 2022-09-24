//The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

//Find the sum of all the primes below two million.

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
        counter++;
    }

    return primes.ToArray();
}

var manyPrimes = GetPrimes(2000000);

long sum = 0;
foreach( var x in manyPrimes )
{
    sum += x;
}

Console.WriteLine(sum);

sw.Stop();
Console.WriteLine($"Elapsed: {sw.Elapsed.TotalSeconds} seconds");