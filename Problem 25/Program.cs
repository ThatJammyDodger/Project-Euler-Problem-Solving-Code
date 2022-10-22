/*  The Fibonacci sequence is defined by the recurrence relation:

    Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
    Hence the first 12 terms will be:

    F1 = 1
    F2 = 1
    F3 = 2
    F4 = 3
    F5 = 5
    F6 = 8
    F7 = 13
    F8 = 21
    F9 = 34
    F10 = 55
    F11 = 89
    F12 = 144
    The 12th term, F12, is the first term to contain three digits.

    What is the index of the first term in the Fibonacci sequence to contain 1000 digits?  */

using System.Diagnostics;
using System.Numerics;

Stopwatch sw = Stopwatch.StartNew();

BigInteger x = 1, y = 1;
int fibindex = 2;

while (true)
{
    x = x + y;
    fibindex ++;
    if (x.ToString().Length == 1000) 
        break;
    y = x + y;
    fibindex ++;
    if (y.ToString().Length == 1000)
        break;
}

Console.WriteLine("Index of firsth Fibonacci number with 1000 digits is {0}.", fibindex);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);