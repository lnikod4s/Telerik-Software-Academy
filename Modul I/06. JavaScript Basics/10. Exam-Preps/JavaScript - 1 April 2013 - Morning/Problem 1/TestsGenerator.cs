using System;
using System.Collections.Generic;
using System.IO;

class TestsGenerator
{
    const string ZeroTestsFormat = "test.000.{0:000}.in.txt";
    const string TestsFormat = "test.{0:000}.in.txt";
    static string Path = Environment.CurrentDirectory + @"\Tests\";

    static void Main()
    {
        Directory.CreateDirectory(Path);
        Random rand = new Random();
        List<int> tests = new List<int>() { 10, 50, 100, 200, 500, 1000, 2000, 5000, 8000, 10000 };
        for (int i = 0; i < tests.Count; i++)
        {
            using (StreamWriter sw = new StreamWriter(Path + string.Format(TestsFormat, i + 1)))
            {
                sw.WriteLine(tests[i]);
                for (int j = 0; j < tests[i]; j++)
                {
                    sw.WriteLine(rand.Next(-2000000000, 2000000000));
                }
            }
        }
    }
}
