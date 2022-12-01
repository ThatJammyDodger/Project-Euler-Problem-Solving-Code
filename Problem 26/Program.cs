/*  A unit fraction contains 1 in the numerator. 
    The decimal representation of the unit fractions with denominators 2 to 10 are given:

    1 / 2 = 0.5
    1 / 3 = 0.(3)
    1 / 4 = 0.25
    1 / 5 = 0.2
    1 / 6 = 0.1(6)
    1 / 7 = 0.(142857)
    1 / 8 = 0.125
    1 / 9 = 0.(1)
    1 / 10 = 0.1
    Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. 
        It can be seen that 1/7 has a 6-digit recurring cycle.

    Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

string recip_div(int n) // finds the string division result for 1/n
{
    string result = "0.";
    List<int> rems = new List<int>() { 1 };
    int need_ind = 0;
    bool done = false;
    do
    {
        int current = rems[rems.Count - 1] * 10;
        result += (current / n).ToString();
        int nrem = current - (current / n) * n;
        rems.Add(nrem);
        for (int i = 0; i < rems.Count; i++)
        {
            if (rems[i] == rems[rems.Count - 1])
                need_ind = rems.Count - i;
            done = true;
        }
        if (rems[rems.Count - 1] == 0)
            if (n < 10)
            {
                done = true;
            }
            else
            {

            }
    } while (!done);
    return result.ToString();
}

for (int i = 2; i <= 100; i++)
{
    Console.WriteLine(recip_div(i));
}





sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);