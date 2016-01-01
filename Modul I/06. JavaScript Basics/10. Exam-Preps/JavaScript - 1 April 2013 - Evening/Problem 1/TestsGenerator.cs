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
        List<int> tests = new List<int>() { 10, 20, 50, 100, 150, 200, 300, 400, 500, 500 };
        for (int i = 0; i < tests.Count; i++)
        {
            using (StreamWriter sw = new StreamWriter(Path + string.Format(TestsFormat, i + 1)))
            {
                sw.WriteLine(tests[i]);
                for (int j = 0; j < tests[i]; j++)
                {
                    sw.WriteLine(rand.Next(-2000000, 2000000));
                }
            }
        }
    }
}
