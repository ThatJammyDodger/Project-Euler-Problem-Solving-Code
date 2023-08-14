/*  The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

    Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

    NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.  */

using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();

int found = 0;
List<int> answers = new ();
SortedSet<int> GetPrimes(int upperLimit)  // gets the primes up to limit
{
    int sieveBound = (int)(upperLimit - 1) / 2;
    int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;
    SortedSet<int> numbers = new()
    {
        (int)(upperLimit / (Math.Log(upperLimit) - 1.08366))
    };
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
    return numbers;
}
SortedSet<int> searchPrimes = GetPrimes(1000000);
SortedSet<int> realPrimes = GetPrimes(1000000);
searchPrimes.RemoveWhere(x => x < 10);


foreach (int prime in searchPrimes)
{
    if (!checkValid(prime))
        continue;

    answers.Add(prime);
    found++;

    if (found >= 11)
        break;
}

bool checkValid(int num)
{
    if(!TruncateableL_R(num)||!TruncateableR_L(num))
        return false;
    return true;
}

bool TruncateableL_R(int prime)
{
    string checking = prime.ToString();
    int extra = Int32.Parse(checking);

    while (checking.Length > 1)
    {
        checking = checking.Substring(0, checking.Length - 1);
        extra = Int32.Parse(checking);
        if (!isPrime(extra))
            return false;
    }

    return true;
}
bool TruncateableR_L(int prime)
{
    string checking = prime.ToString();
    int extra = Int32.Parse(checking);

    while (checking.Length>1)
    {
        checking = checking.Substring(1);
        extra = Int32.Parse(checking);
        if (!isPrime(extra))
            return false;
    }

    return true;
}
bool isPrime(int suspect)
{
    if (realPrimes.Contains(suspect))
        return true;
    return false;
}

int sum = 0;

foreach (int answer in answers)
{
    Console.WriteLine(answer);
    sum += answer;
}

Console.WriteLine("\nRequired sum is: {0}. Have a nice day", sum);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", Math.Ceiling(sw.Elapsed.TotalMilliseconds));