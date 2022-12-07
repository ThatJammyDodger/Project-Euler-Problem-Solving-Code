/*  The decimal number, 585 = 1001001001 (binary), is palindromic in both bases.

    Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

    (Please note that the palindromic number, in either base, may not include leading zeros.)*/

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

List<int> dpal = new();

bool IsPalindrome(string input)
{
    char[] chars = input.ToCharArray();
    chars = chars.Reverse().ToArray();
    string newstr = new string(chars);
    return newstr == input;
}

for (int i = 1; i < 1000000; i++)
{
    if (IsPalindrome(i.ToString()))
        dpal.Add(i);
}

List<int> dbpal = new();
foreach (var num in dpal)
{
    if (IsPalindrome(Convert.ToString(num, 2)))
        dbpal.Add(num);
}

int sum = 0;
foreach (int number in dbpal)
{
    sum += number;
}

Console.WriteLine("The sum of palindromes under one million in both base-10 and base-2 is {0}", sum);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);