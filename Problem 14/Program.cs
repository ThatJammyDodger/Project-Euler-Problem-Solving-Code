/*  The following iterative sequence is defined for the set of positive integers:

    n → n / 2 (n is even)
    n → 3n + 1 (n is odd)

    Using the rule above and starting with 13, we generate the following sequence:

    13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms.Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

    Which starting number, under one million, produces the longest chain?

    NOTE: Once the chain starts the terms are allowed to go above one million.  */

using System.Diagnostics;
using System.Numerics;

Stopwatch sw = Stopwatch.StartNew();

int longest_chain = 0;
int longest_chain_starter = 1;

for (int i = 1; i <= 1000000; i++)
{
    BigInteger value = i;
    int current_chain = 1;
    while (value != 1)
    {
        if (value % 2 == 0)
            value /= 2;
        else
            value = 1 + (value * 3);
        current_chain++;
    }
    if (current_chain > longest_chain)
    {
        longest_chain = current_chain;
        longest_chain_starter = i;
    }
}

Console.WriteLine($"Longest chain = {longest_chain}.\nLongest chain starter = {longest_chain_starter}");

sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed.TotalSeconds} seconds");