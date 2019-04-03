using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;


namespace t1
{
    class Tester
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Console.WriteLine("Please enter the parameters you wish to be executed(-help for help, -exit to exit program)");

            while (!exit)
            {

                string input = Console.ReadLine();

                if (input == "-exit")
                    exit = true;
                else
                {
                    Process p = new Process();

                    p.StartInfo.FileName = "p1.exe";
                    p.StartInfo.Arguments = input;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.Start();
                    Console.WriteLine(p.StandardOutput.ReadToEnd());
                    p.WaitForExit();
                }
            }
        }
    }
}
