/*  Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

    For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284.
    The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

    Evaluate the sum of all the amicable numbers under 10000.  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

// SUM OF FACTORS OF A NUMBER ALGORITHM
int SumOfFactors(int number)
{
    List<int> PrimeFactorArr = PrimeFactors(number).ToList();

    List<List<int>> PrimeFactorList = new();

    while (PrimeFactorArr.Count > 0)
    {
        int cnum = PrimeFactorArr[0];
        int count = PrimeFactorArr.Where(x => x.Equals(cnum)).Count();
        PrimeFactorList.Add(new List<int> { cnum, count });
        for (int i = 0; i < count; i++)
        {
            PrimeFactorArr.RemoveAt(0);
        }
    }
    int sum = 1;
    for (int i = 0; i < PrimeFactorList.Count; i++)
    {
        var current_pair = PrimeFactorList[i];
        int tempsum = 0;
        for (int j = 0; j<= current_pair[1]; j++)
        {
            tempsum += (int)Math.Pow(current_pair[0], j);
        }
        sum*=tempsum;
    }
    return (sum - number);  // this specific to question
}

// PRIME FACTORS OF A NUMBER ALGORITHM
int[] PrimeFactors(int n)
{
    List<int> results = new List<int>();
    while (n % 2 == 0)
    {
        results.Add(2);
        n /= 2;
    }

    for (int i = 3; i <= Math.Sqrt(n); i += 2)
    {
        while (n % i == 0)
        {
            results.Add(i);
            n /= i;
        }
    }
    if (n > 2) { results.Add(n); }

    return results.ToArray();
}

List<int> Amicables = new();

for (int i = 2; i<10000; i++)
{
    if (Amicables.Contains(i))
        continue;

    int sumfi = SumOfFactors(i);
    int sumfifi = SumOfFactors(sumfi);
    if (sumfifi == i && i!=sumfi)
    {
        Amicables.Add(sumfi);
        Amicables.Add(i);
    }
}

Console.WriteLine("Amicables: ");
for (int i = 0; i < Amicables.Count; i++)
{
    Console.WriteLine("{0}", Amicables[i]);
}

int sum = 0;
foreach(var x in Amicables)
{
    sum += x;
}

Console.WriteLine("Sum of amicables under 10000 is {0}.", sum);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);