// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

long HCF(long i, long j)
{
    long x = (i > j) ? i : j;
    long y = (i < j) ? i : j;

    long rem = -1;

    while (rem != 0)
    {
        long mult = x / y;
        rem = x - y * mult;
        if (rem != 0)
        {
            x = y;
            y = rem;
        }
    }
    return y;
}


// LCM ALGORITHM
long LCM(long i, long j)
{
    return (i * j) / HCF(i, j);
}

long current_lcm = 1;
for(long i = 1; i<=20; i++)
{
    current_lcm = LCM(current_lcm, i);
}

Console.WriteLine(current_lcm);