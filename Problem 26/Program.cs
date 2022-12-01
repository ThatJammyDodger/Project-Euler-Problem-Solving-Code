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
        int nrem = current - (current/n)*n;
        rems.Add(nrem);
        for (int i = 0; i < rems.Count-1; i++)
        {
            if (rems[i] == rems[rems.Count - 1])
            {
                need_ind = rems.Count - i;
                done = true;
            }
        }
        if (rems[rems.Count - 1] == 0)
        {
            done = true;
        }
    } while (!done);
    return result;
}

int longest_res_num = 0;
int longest_res_len = 0;

for (int i = 2; i < 1000; i++)
{
    if (recip_div(i).Length > longest_res_len)
    {
        longest_res_num = i;
        longest_res_len = recip_div(i).Length;
    }
}

Console.WriteLine("The number below 1000 with the longest recurring cycle is {0} with a decimal length (without repeats) of {1}.",longest_res_num, longest_res_len);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);