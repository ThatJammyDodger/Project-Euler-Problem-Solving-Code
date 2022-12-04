/*  We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once;
    for example, the 5-digit number, 15234, is 1 through 5 pandigital.

    The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

    Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

    HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.  */

using System.Diagnostics;
using System.Net.Http.Headers;

Stopwatch sw = Stopwatch.StartNew();

SortedSet<int> pandig_prods = new();

bool isSuitable(string a, string b, string c)
{
    string concat = a + b + c;
    foreach (char x in concat)
    {
        if (x < '1' || x > '9')
            return false;
    }
    if (concat.Length != 9)
        return false;
    return concat.Distinct().Count() == concat.Length;
}

for (int a = 1; a <= 99999; a++)
{
    for (int b = 1; b <= 100; b++)
    {
        
        if (isSuitable(a.ToString(), b.ToString(), (a * b).ToString()))
        {
            Console.WriteLine("{0} × {1} = {2}", a, b, a * b);
            pandig_prods.Add(a*b);
        }
    }
}

int totalset = 0;

foreach(int num in pandig_prods)
{
    totalset += num;
}

Console.WriteLine("Required answer: " + totalset);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);