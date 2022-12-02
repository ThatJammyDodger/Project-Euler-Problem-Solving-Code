/*  Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

    1634 = 14 + 64 + 34 + 44
    8208 = 84 + 24 + 04 + 84
    9474 = 94 + 44 + 74 + 44
    As 1 = 14 is not a sum it is not included.

    The sum of these numbers is 1634 + 8208 + 9474 = 19316.

    Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

List<int> good_nums = new();

int[] fifth_pow_precalcs = new int[10];
for (int i = 0; i < 10; i++)
{
    fifth_pow_precalcs[i] = (int)Math.Pow(i, 5);
}

string stringed = String.Empty;
int temp_tot;

for (int i = 2; i < 354294; i++)
{
    temp_tot = 0;
    stringed = i.ToString();
    foreach (char x in stringed)
    {
        temp_tot += fifth_pow_precalcs[(int)Char.GetNumericValue(x)];
    }
    if (temp_tot == i)
        good_nums.Add(i);
}
temp_tot = 0;
foreach (var x in good_nums)
{
    temp_tot += x;
}

Console.WriteLine("The sum of all the numbers that can be written as the sum of fifth powers of their digits is {0}.", temp_tot);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);