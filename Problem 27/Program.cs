/*  Euler discovered the remarkable quadratic formula: n^2+n+41


    It turns out that the formula will produce 40 primes for the consecutive integer values . However, when  is divisible by 41, and certainly when  is clearly divisible by 41.

    The incredible formula  was discovered, which produces 80 primes for the consecutive values . The product of the coefficients, −79 and 1601, is −126479.

    Considering quadratics of the form:

    n^2 + an + b, where |a| < 1000 and |b| <= 1000

    where |n| is the modulus/absolute value of n
    e.g. |11| = 11 and |-4| = 4
    Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.  */

using System.Collections.Generic;
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
bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 3; i <= boundary; i += 2)
        if (number % i == 0)
            return false;

    return true;
}

List<int> b_pot_values = new List<int>(GetPrimes(1000)); 

int testing(int a, int b)
{
    int counter = 0;
    while (true)
    {
        if (!IsPrime(counter * counter + counter * a + b))
            return counter;
        counter++;
    }
}

int max_so_far = 0;
int a_for_maxsf = 0;
int b_for_maxsf = 0;

for (int a = -999; a < 1000; a++)
{
    foreach (int b in b_pot_values)  // as mathematically, b must also be prime
    {
        var tempr = testing(a, b);
        if (tempr > max_so_far)
        {
            max_so_far = tempr;
            a_for_maxsf = a;
            b_for_maxsf = b;
        }
    }
}

Console.WriteLine("Producing the longest prime chain length of {0}, a={1}, b={2}, ab={3}",max_so_far, a_for_maxsf, b_for_maxsf, a_for_maxsf*b_for_maxsf);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);