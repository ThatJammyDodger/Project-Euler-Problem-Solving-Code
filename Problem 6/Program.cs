//The sum of the squares of the first ten natural numbers is 385,

//The square of the sum of the first ten natural numbers is 3025,

//Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025-385 = 2640.

//Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.



// sum of the squares of the first n numbers
long sumsquare(long n)
{
    long sum = 0;
    for (int i = 1; i <= n; i++)
    {
        sum += Convert.ToInt64(Math.Pow(i, 2));
    }
    return sum;
}

long squaresum(long n)
{
    return Convert.ToInt64(Math.Pow((n/2)*(n+1),2));
}

long difference(long n) => Math.Abs(sumsquare(n) - squaresum(n));

Console.WriteLine(squaresum(100));
Console.WriteLine(sumsquare(100));
Console.WriteLine(difference(100));