/*
By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route.
However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ; o)
*/

using System.Diagnostics;
using System.Reflection;

Stopwatch sw = Stopwatch.StartNew();

string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"..\..\..\numbers.txt");
string text = File.ReadAllText(path);

List<List<int>> numbers = new();

using var r = new StringReader(text);
string line;
while ((line = r.ReadLine()!) is not null)
{
    numbers.Add(line.Split(" ").ToList().Select(int.Parse).ToList());
}

// Theorised method which works here checked is to check, from the current number, which path over the next two rows, out of all possibilities, gives the best addition to total.

int[] highest_next_row(int[] startIndex)
{
	int next1 = numbers[startIndex[0]][startIndex[1]+1] ;
	int next2 = numbers[startIndex[0] + 1][startIndex[1]+1];
	int higher = next1 > next2 ? next1 : next2 ;
	return new int[] { next1 > next2 ? startIndex[0] : startIndex[0]+1 , startIndex[1], higher };  // in format ( int[2] new_index, value_of_this )
}

int check_next_rows(int[] startIndex) // start index in form { i, j } so i = startIndex[0] & j=startIndex[1]
{
	int potential_sum_1 = 0;
	int potential_sum_2 = 0;

	int[] potential_sum_1_ind = new int[] { startIndex[0], startIndex[1]+1 };
	int[] potential_sum_2_ind = new int[] { startIndex[0]+1, startIndex[1]+1 };

    potential_sum_1 = numbers[potential_sum_1_ind[0]][potential_sum_1_ind[1]] + highest_next_row(potential_sum_1_ind)[2];
    potential_sum_2 = numbers[potential_sum_2_ind[0]][potential_sum_2_ind[1]] + highest_next_row(potential_sum_2_ind)[2];

	return potential_sum_1 > potential_sum_2 ? potential_sum_1 : potential_sum_2;
}

Console.WriteLine(numbers[1][1]);

//Console.WriteLine(check_next_rows(new int[] { 0, 0 }));

sw.Stop();
Console.WriteLine("Elapsed time: {0} ms", sw.Elapsed.TotalMilliseconds);