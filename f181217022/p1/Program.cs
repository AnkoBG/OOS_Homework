using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d1;

namespace p1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> parameters = args.ToList();

            if (parameters.Contains("-help"))
                FileEditor.DisplayHelp();
            else
                for (int i = 0; i < parameters.Count; i++)
                {
                    //Parse commands only
                    if (parameters[i][0] != '-')
                    {
                        continue;
                    }

                    // Next parameter must exist and mustn't be a command.
                    bool nextParamCheck = parameters.Count - 1 >= i + 1 && parameters[i + 1][0] != '-';

                
                    if (nextParamCheck)
                    {
                        string file = parameters[i + 1];

                        switch (parameters[i])
                        {
                            case "-gen":
                                // 2nd parameter can only be an int(the number's length).
                                if (parameters.Count - 1 >= i + 2 && int.TryParse(parameters[i + 2], out int length))
                                    FileEditor.Gen(file, length);
                                else
                                    FileEditor.Gen(file);
                                break;
                            case "-view":
                                FileEditor.View(file);
                                break;
                            case "-sort":
                                FileEditor.Sort(file);
                                break;
                            case "-sortdesc":
                                FileEditor.Sort(file, true);
                                break;
                            default:
                                Console.WriteLine("Unknown command: {0}", parameters[i]);
                                break;
                        }
                    }
                }
        }
    }
}
