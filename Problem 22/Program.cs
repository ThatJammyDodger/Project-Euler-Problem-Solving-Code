/*  Using names.txt(right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
    Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

    For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

    What is the total of all the name scores in the file?  */

using System.Diagnostics;
using System.Reflection;
using System.Text;

Stopwatch sw = Stopwatch.StartNew();

string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"..\..\..\names.txt");
string text = File.ReadAllText(path);

string[] temp = text.Replace(" ", "").Split(",");
List<string> names = new();

foreach(var x in temp)
{
    names.Add(x.Replace("\"", ""));
}

names.Sort();

int LetterSum(string word) // with capitals
{
    byte[] asciiBytes = Encoding.ASCII.GetBytes(word);
    int lsum = 0;
    foreach (var x in asciiBytes)
    {
        lsum+=Convert.ToInt32(x)-64;
    }
    return lsum;
}

long namescoresum = 0;
for (int i = 1; i <= names.Count; i++)
{
    namescoresum += i * LetterSum(names[i - 1]);
}

Console.WriteLine("Total name score of file is {0}.", namescoresum);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);