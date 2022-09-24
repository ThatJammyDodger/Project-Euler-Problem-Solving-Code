//By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

//What is the 10 001st prime number?

using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();

int[] GetPrimes (int n)  // gets the first n prime numbers
{
    List<int> primes = new() { 2 };

    int counter = 3;
    while (primes.Count < n)
    {
        bool prime = true;
        foreach(var x in primes)
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

var somePrimes = GetPrimes(10001);

sw.Stop();

Console.WriteLine(somePrimes[somePrimes.Length - 1]);

Console.WriteLine(sw.Elapsed.TotalSeconds + " seconds");