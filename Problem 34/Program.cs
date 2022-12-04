/*  145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

    Find the sum of all numbers which are equal to the sum of the factorial of their digits.

    Note: As 1! = 1 and 2! = 2 are not sums they are not included.  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

int factorial(int n)
{
    int prod = 1;
    for (int i = 2; i <= n; i++)
    {
        prod *= i;
    }
    return prod;
}

int sum = 0;
int tot;

for (int i = 3; i <= 2540160; i++)  // up to the maximum viable number based on value of 9!
{
    tot = 0;
    foreach(char x in i.ToString())
    {
        tot += factorial((int)Char.GetNumericValue(x));
    }
    if (tot == i)
        sum += tot;
}

Console.WriteLine("The sum of all numbers which are equal to the sum of the factorial of their digits is {0}", sum);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);