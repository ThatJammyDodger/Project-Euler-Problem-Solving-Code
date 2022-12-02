/*  In the United Kingdom the currency is made up of pound (£) and pence(p). There are eight coins in general circulation:

    1p, 2p, 5p, 10p, 20p, 50p, £1(100p), and £2(200p).
    It is possible to make £2 in the following way:

    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    How many different ways can £2 be made using any number of coins?  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

int total_ways = 1; // £2 coin included off the bat

for (int a = 0; a <= 200; a++)
{
    for (int b = 0; b <= 100; b++)
    {
        for (int c = 0; c <= 40; c++)
        {
            for (int d = 0; d <= 20; d++)
            {
                for (int e = 0; e <= 10; e++)
                {
                    for (int f = 0; f <=  4; f++)
                    {
                        for (int g = 0; g <= 2; g++)
                        {
                            if (a + 2*b + 5*c + 10*d + 20*e + 50*f + 100*g == 200)
                                total_ways++;
                        }
                    }
                }
            }
        }
    }
}

Console.WriteLine("The total number of ways to make £2 is {0}.", total_ways);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);