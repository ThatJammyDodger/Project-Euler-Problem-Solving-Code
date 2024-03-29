﻿//  If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

//  If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?


//  NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
//  The use of "and" when writing out numbers is in compliance with British usage.

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

Func<string, int> letters_in_num = (string x) => x.Replace(" ", "").Replace("-", "").Trim().Length;

Dictionary<string, string> numbers = new Dictionary<string, string>
{
    { "1" , "one" },
    { "2" , "two" },
    { "3" , "three" },
    { "4" , "four" },
    { "5" , "five" },
    { "6" , "six" },
    { "7" , "seven" },
    { "8" , "eight" },
    { "9" , "nine" },
    { "10" , "ten" },
    { "11" , "eleven" },
    { "12" , "twelve" },
    { "13" , "thirteen" },
    { "14" , "fourteen" },
    { "15" , "fifteen" },
    { "16" , "sixteen" },
    { "17" , "seventeen" },
    { "18" , "eighteen" },
    { "19" , "nineteen" },
    { "20" , "twenty" },
    { "30" , "thirty" },
    { "40" , "forty" },  // spelt as 'fourty' originally, to my own regret
    { "50" , "fifty" },
    { "60" , "sixty" },
    { "70" , "seventy" },
    { "80" , "eighty" },
    { "90" , "ninety" }, // just "hundred", NOT "one-hundred"
    { "1000", "one thousand" }  // this actually is 'one thousand' full
};

string total_letters = "";

for (int i = 21; i < 100; i++)
{
    if (!numbers.ContainsKey(i.ToString()))
    {
        string tens_digit_stuff = i.ToString()[0] + "0";

        string i_in_letters = numbers[tens_digit_stuff] + "-" + numbers[i.ToString()[1].ToString()];

        numbers.Add(i.ToString(), i_in_letters);
    }
}

for (int i = 100; i < 1000; i++)
{
    if (!numbers.ContainsKey(i.ToString()))
    {
        string hundreds_digit_stuff = numbers[i.ToString()[0].ToString()] + " hundred";
        int without_hundreds_digit = i - (i/100)*100;

        string i_in_letters = i%100!=0? hundreds_digit_stuff + " and " + numbers[without_hundreds_digit.ToString()] : hundreds_digit_stuff ;

        numbers.Add(i.ToString(), i_in_letters);
    }
}

foreach(KeyValuePair<string, string> pair in numbers.OrderBy(key => Int32.Parse(key.Key)))
{
    total_letters += pair.Value;
}

Console.WriteLine("There are {0} total letters here", letters_in_num(total_letters));

sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed.TotalMilliseconds} ms");