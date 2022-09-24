// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

// Find the largest palindrome made from the product of two 3-digit numbers.

int[] highest = new int[3];

for (int i=100; i<1000; i++)
{
    for (int j=100; j<1000; j++)
    {
        if (CheckPalindrome(i * j))
        {
            if (i * j > highest[0])
            {
                highest[0] = i * j;
                highest[1] = i;
                highest[2] = j;
            }
        }
    }
}

bool CheckPalindrome(int n)
{
    string strung_n = n.ToString();
    string backwards = "";
    for(int i=strung_n.Length-1; i>=0; i--)
    {
        backwards+=strung_n[i];
    }
    return strung_n==backwards;
}

Console.WriteLine($"{highest[0]} = {highest[1]} * {highest[2]}");