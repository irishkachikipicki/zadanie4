using System;

class Program
{
    static void Main()
    {
        string str1 = "hello";
        string str2 = "world";

        int result = CompareStrings(str1, str2);

        if (result > 0)
            Console.WriteLine("The first string is greater than the second string lexically.");
        else if (result < 0)
            Console.WriteLine("The first string is less than the second string lexically.");
        else
            Console.WriteLine("The strings are equal lexically.");
    }

    static int CompareStrings(string str1, string str2)
    {
        int minLength = Math.Min(str1.Length, str2.Length);

        for (int i = 0; i < minLength; i++)
        {
            if (str1[i] != str2[i])
            {
                return str1[i] - str2[i];
            }
        }

        return str1.Length - str2.Length;
    }
}

class RandomStringGenerator
{
    static Random random = new Random();

    public string GenerateString(int n, bool lettersOnly, bool numbersOnly)
    {
        string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        if (lettersOnly)
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (numbersOnly)
            chars = "0123456789";

        char[] stringChars = new char[n];

        for (int i = 0; i < n; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }
}

class CompareToTester
{
    RandomStringGenerator generator = new RandomStringGenerator();

    public void TestCompareTo()
    {
        for (int i = 1; i <= 1000; i++)
        {
            string str1 = generator.GenerateString(10, false, false);
            string str2 = generator.GenerateString(10, false, false);

            int result1 = CompareStrings(str1, str2);
            int result2 = String.Compare(str1, str2);

            if (result1 == result2)
                Console.WriteLine("---------test " + i + " is successful");
            else
                Console.Error.WriteLine("---------test " + i + " is invalid");
        }
    }
}
