//  2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

//  What is the sum of the digits of the number 2^1000?

using System.Diagnostics;
using System.Numerics;
Stopwatch sw = Stopwatch.StartNew();

BigInteger number = 1;

for (int i = 0; i < 1000; i++)
{
    number = number * 2;
}

string num = number.ToString();

int digit_sum = 0;
foreach(char c in num)
{
    digit_sum += Int32.Parse(c.ToString());
}

Console.WriteLine($"Digit sum of 2^1000 is {digit_sum}");
sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");