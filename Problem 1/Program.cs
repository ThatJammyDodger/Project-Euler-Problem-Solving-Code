using System.Collections.Generic;

int[] integers = new int[999];
for (int i = 1;  i<=999; i++)
{
    integers[i-1] = i;
}

int sum = 0;
foreach(var x in integers)
{
    if (x%3==0 || x % 5 == 0)
    {
        sum += x;
    }
}

Console.WriteLine($"Sum is {sum}.");