using System;
using System.IO;
using System.Text;
namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"data.txt";
            int n = int.Parse(Console.ReadLine());
            Random random = new Random();
            if (!File.Exists(path))
            {
                string[] generated = new string[n];
                StringBuilder sb;
                for (int i = 0; i < n; i++)
                {
                    sb = new StringBuilder();
                    for (int j = 0; j < 5; j++)
                    {
                        sb.Append(random.Next(10, 100).ToString());
                        sb.Append(" ");
                    }
                    generated[i] = sb.ToString();
                }
                File.WriteAllLines(path, generated);
                string[] lines = File.ReadAllLines(path);
                int chet = 0;
                int nechet = 0;
                foreach (string item in lines)
                {
                    string[] nums = item.Split(' ');
                    foreach (string num in nums)
                    {
                        int current = 0;
                        int.TryParse(num, out current);
                        if (current % 2 == 0)
                        {
                            chet++;
                        }
                        else
                        {
                            nechet++;
                        }
                    }
                }
                int[] chetIndexes = new int[chet];
                int[] nechetIndexes = new int[nechet];
                int[] allNumbers = new int[chet + nechet];
                int index = 0, indexChet = 0, indexNechet = 0;
                foreach (var item in lines)
                {
                    int current = 0;
                    string[] nums = item.Split();
                    foreach (var num in nums)
                    {
                        int.TryParse(num, out current);
                        allNumbers[index] = current;
                        index++;
                    }
                }
                for (int i = 0; i < allNumbers.Length; i++)
                {
                    if (allNumbers[i] % 2 == 0)
                    {
                        chetIndexes[indexChet] = i;
                        indexChet++;
                    }
                    else
                    {
                        nechetIndexes[indexNechet] = i;
                        indexNechet++;
                    }
                }
                foreach (var item in chetIndexes)
                {
                    Console.Write(allNumbers[item] + " ");
                }
                Console.WriteLine("");
                foreach (var item in nechetIndexes)
                {
                    Console.Write(allNumbers[item] + " ");
                }
            }
        }
    } // end of Program
}