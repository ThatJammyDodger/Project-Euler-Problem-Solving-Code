/*  You are given the following information, but you may prefer to do some research for yourself.

    1 Jan 1900 was a Monday.
    Thirty days has September,
    April, June and November.
    All the rest have thirty-one,
    Saving February alone,
    Which has twenty-eight, rain or shine.
    And on leap years, twenty-nine.
    A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.

    How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?  */

using System.Diagnostics;
Stopwatch sw = Stopwatch.StartNew();

//var days_vs_dates = new Dictionary<DateTime, string>();

int tally = 0;

var add_date = new DateTime(1901, 1, 1);
while (true)
{
    if (add_date.Year == 2001 && add_date.Month == 1 && add_date.Day == 1)
        break;

    if (add_date.Day==1 && add_date.DayOfWeek == DayOfWeek.Sunday)
        tally++;

    add_date = add_date.AddDays(1);
}

Console.WriteLine("There are a total of {0} Sundays in this period.", tally);

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);