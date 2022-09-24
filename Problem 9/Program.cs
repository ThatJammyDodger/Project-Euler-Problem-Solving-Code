//A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

//a^2 + b^2 = c^2
//For example, 32 + 42 = 9 + 16 = 25 = 52.

//There exists exactly one Pythagorean triplet for which a + b + c = 1000.
//Find the product abc.

using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();

List<int[]> pairs_ab = new();

for (int a = 1; a < 1000; a++)
{
    for (int b = 1; b < 1000; b++)
    {
        if (Math.Sqrt((a * a) + (b * b)) % 1 == 0)
        {
            pairs_ab.Add(new int[] { a, b });
        }
    }
}

foreach(var x in pairs_ab)
{
    if ((x[0] + x[1] + (Math.Sqrt(Math.Pow(x[0], 2) + Math.Pow(x[1], 2)))) == 1000)
    {
        Console.WriteLine($"a={x[0]}, b={x[1]}, c={(Math.Sqrt(Math.Pow(x[0], 2) + Math.Pow(x[1], 2)))}");
        Console.WriteLine($"The product abc is equal to {x[0] * x[1] * (Math.Sqrt(Math.Pow(x[0], 2) + Math.Pow(x[1], 2)))}");

        break;
    }
}

sw.Stop();
Console.WriteLine($"\nElasped: {sw.Elapsed.TotalMilliseconds} milliseconds\n");