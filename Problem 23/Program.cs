/*  A perfect number is a number for which the sum of its proper divisors is exactly equal to the number.
 *  For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

    A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

    As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
    By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers.
    However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be
    expressed as the sum of two abundant numbers is less than this limit.

    Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.  */

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
        for (int j = 0; j <= current_pair[1]; j++)
        {
            tempsum += (int)Math.Pow(current_pair[0], j);
        }
        sum *= tempsum;
    }
    return sum - number; // for this question 'proper' divisors only
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

List<int> AbundantNumbers = new();

for (int i = 1; i<=28123; i++)
{
    if (SumOfFactors(i) > i)
        AbundantNumbers.Add(i);
}

Console.WriteLine(AbundantNumbers.Count);



sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);