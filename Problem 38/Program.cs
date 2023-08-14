/* Take the number 192 and multiply it by each of 1, 2, and 3: 192, 384, 576 respectively.
 
By concatenating each product we get the 1 to 9 pandigital, 192,384,576.
We will call this the concatenated product of 192 and (1,2,3).

The same can be achieved by starting with 9 and multiplying by (1,2,3,4,5), giving the
pandigital 918,273,645.

What is the largest 1 to 9 pandigital 9-digit number
that can be formed as the concatenated product of an integer with 
(1,2,...,n) where n > 1?
*/


bool isPandigital(int num)
{
    if (!(num.ToString().Length == 9))
        return false;
    else if (!(num.ToString().Contains("0")))
        return false;
    foreach (char x in num.ToString())
    {
        List<char> nums = new();
        if (!nums.Contains(x))
            nums.Add(x);
        else
            return false;
    }
    return true;
}

Console.WriteLine(isPandigital(123456789));
Console.WriteLine(isPandigital(123987654));
Console.WriteLine(isPandigital(12349));
Console.WriteLine(isPandigital(123456788));
Console.WriteLine(isPandigital(1234567890));
Console.WriteLine(isPandigital(1234567899));
Console.WriteLine(isPandigital(918273645));