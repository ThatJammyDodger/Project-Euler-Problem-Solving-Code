/*  The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.

    We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

    There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.

    If the product of these four fractions is given in its lowest common terms, find the value of the denominator.  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

Console.WriteLine("Here are the required fractions:");

for (double a = 1; a < 10; a++)
{
    for (double b = 1; b < 10; b++)
    {
        for (double c = 1; c < 10; c++)
        {
            if (((10 * a + b) / (10 * b + c)) == (a / c) && a!=b)
            {
                Console.WriteLine($"{10*a+b}/{10*b+c} = {a}/{c}");
            }
        }
    }
}

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);