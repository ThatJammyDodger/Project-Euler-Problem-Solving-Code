/*  n! means n × (n − 1) × ... × 3 × 2 × 1

    For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

    Find the sum of the digits in the number 100!  */

using System.Numerics;
using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

BigInteger BigNum = 1;
for (int i = 1; i <= 100; i++)
{
    BigNum *= i;
}
string StringNum = BigNum.ToString();
int SumNum = 0;
foreach(var x in StringNum)
{
    SumNum += Int32.Parse(x.ToString());
}

Console.WriteLine("The digit sum of 100! is {0}.", SumNum);
sw.Stop();

Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);