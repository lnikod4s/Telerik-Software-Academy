using System;

class Solution
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int count = 1;
        int last = int.Parse(Console.ReadLine());
        for (int i = 1; i < N; i++)
        {
            int current = int.Parse(Console.ReadLine());
            if (current < last)
            {
                count++;
            }
            last = current;
        }

        Console.WriteLine(count);
    }
}
