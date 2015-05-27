using System;

class Soluion
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] arr = new int[N];
        for (int i = 0; i < N; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = int.MinValue;

        for (int i = 0; i < N; i++)
        {
            for (int j = i; j < N; j++)
            {
                int localSum = 0;
                for (int k = i; k <= j; k++)
                {
                    localSum += arr[k];
                }

                if (localSum > maxSum)
                {
                    maxSum = localSum;
                }    
            }
        }

        // There is a smarter solution using prefix sums
        // Prefix sums will remove the need of the most inner loop
        // More information on prefix sums: http://en.wikipedia.org/wiki/Prefix_sum

        Console.WriteLine(maxSum);
    }
}
