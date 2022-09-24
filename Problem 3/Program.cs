// The prime factors of 13195 are 5, 7, 13 and 29.

// What is the largest prime factor of the number 600851475143 ?

long[] PrimeFactors(long n)
{
    List<long> results = new List<long>();
    while (n % 2 == 0)
    {
        results.Add(2);
        n /= 2;
    }

    for (int i = 3; i < Math.Sqrt(n); i += 2)
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

long highestpf = 1;
foreach(var x in PrimeFactors(600851475143))
{
    if (x > highestpf)
    {
        highestpf = x;
    }
}

Console.WriteLine(highestpf);