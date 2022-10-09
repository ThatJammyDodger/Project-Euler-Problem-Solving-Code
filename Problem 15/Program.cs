//  Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

//  https://projecteuler.net/project/images/p015.png

//  How many such routes are there through a 20×20 grid?

/*

The overall vector for this is 20i + 20j. We now need to know, out of these 40 steps, how many places could the 20 i moves be in? This can be solved using the nCr formula.
nCr = (n!)/(r!)(n-r)!
Therefore, the answer is 40 'choose' 20.

*/

using System.Diagnostics;
using System.Numerics;

Stopwatch sw = Stopwatch.StartNew();

BigInteger factorial (int num)
{
    BigInteger result = 1;
	for (int i = 2; i <= num; i++)
	{
		result = result * i;
	}
	return result;
}

Console.WriteLine($"Answer is {factorial(40)/(factorial(20)*factorial(20))}");

sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");