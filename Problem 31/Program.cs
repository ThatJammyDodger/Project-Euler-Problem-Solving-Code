/*  In the United Kingdom the currency is made up of pound (£) and pence(p). There are eight coins in general circulation:

    1p, 2p, 5p, 10p, 20p, 50p, £1(100p), and £2(200p).
    It is possible to make £2 in the following way:

    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    How many different ways can £2 be made using any number of coins?  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();



sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);