/*  A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
    If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

      012   021   102   120   201   210

    What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

List<string> permutations = new();
void permute(string strung, string answer)
{
    if (strung.Length == 0)
    {
        permutations.Add(answer);
        return;
    }

    for (int i = 0; i < strung.Length; i++)
    {
        char ch = strung[i];
        string left_substr = strung.Substring(0, i);
        string right_substr = strung.Substring(i + 1);
        string rest = left_substr + right_substr;
        permute(rest, answer + ch);
    }
}

permute("0123456789", "");

permutations.Sort();

Console.WriteLine("The millionth lexicographic permutation is {0}.", permutations[999999]);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);