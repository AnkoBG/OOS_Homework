using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace d1
{
    public static class Class1
    {
        private readonly static string path = "file.txt";

        public static void Gen()
        {
            Random r = new Random();
            List<string> numList = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                numList.Add(r.Next(100).ToString());
            }

            File.WriteAllLines(path, numList);
            Console.WriteLine(path + " generated!");
        }

        public static void View()
        {
            if (File.Exists(path))
            {
                Console.WriteLine(File.ReadAllText(path));
                Console.ReadKey();
            }
            else
                Console.WriteLine(path + " does not exist.");
        }

        public static void Sort()
        {
            List<int> nums = File.ReadAllLines(path).Select(int.Parse).ToList();

            nums.Sort();

            File.WriteAllLines(path, nums.ConvertAll<string>(x => x.ToString()));

            Console.WriteLine(path + " sorted!");
        }
    }
}
