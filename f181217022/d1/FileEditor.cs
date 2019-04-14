using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1
{
    public class FileEditor
    {
        public static void Gen(string filename, int length = 8)
        {
            Random r = new Random();
            string randNum = "";

            for (int i = 0; i < length; i++)
            {
                randNum += r.Next(10).ToString();
            }

            File.WriteAllText(filename, randNum);

            Console.WriteLine("File generated succesfully.");
        }

        public static void View(string filename)
        {
            if(File.Exists(filename))
                Console.WriteLine(File.ReadAllText(filename));
            else
                Console.WriteLine("File does not exist.");
        }

        public static void Sort(string filename, bool reverse = false)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            string numbersString = File.ReadAllText(filename);
            List<int> numsList = new List<int>(0);

            foreach (char num in numbersString)
            {
                if (int.TryParse(num.ToString(), out int number))
                    numsList.Add(number);
            }

            numsList.Sort();

            if (reverse)
                numsList.Reverse();

            numbersString = "";

            foreach (int number in numsList)
            {
                numbersString += number.ToString();
            }
            
            File.WriteAllText(filename, numbersString);
            Console.WriteLine("File sorted succesfully.");
        }

        public static void DisplayHelp()
        {
            Console.WriteLine("Help:");
            Console.WriteLine("-gen {filename} [number length (integer, default is 8)]: Generate numbers and save to file (optionally specify length)");
            Console.WriteLine("-sort {filename}: Sort numbers in a file");
            Console.WriteLine("-sortdesc {filename}: Sort numbers in a file");
            Console.WriteLine("-view {filename}: Display numbers in file to console");
        }
    }
}
