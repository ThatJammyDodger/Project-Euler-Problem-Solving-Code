/*  Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

    21 22 23 24 25
    20  7  8  9 10
    19  6  1  2 11
    18  5  4  3 12
    17 16 15 14 13

    It can be verified that the sum of the numbers on the diagonals is 101.

    What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?  */

using System.Diagnostics;
using System.Numerics;
using System.Xml.Schema;

Stopwatch sw = Stopwatch.StartNew();

// Mathematically, we can find out that the up right diagonal has nth term: 4n^2 - 4n + 1
// Bottom right: 4n^2 - 10n + 7
// Top left: 4n^2 - 6n + 3
// Bottom left: 4n^2 - 8n + 5

long total = -3;

for (int i = 1; i <= 501 ; i++)
{
    total += (4 * i * i) - (4 * i) + 1;
    total += (4 * i * i) - (10 * i) + 7;
    total += (4 * i * i) - (8 * i) + 5;
    total += (4 * i * i) - (6 * i) + 3;
}

Console.WriteLine("The total of the diagonals is {0}.", total);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);