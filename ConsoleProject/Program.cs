using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject
{
    internal class Program
    {
        public static void Parse(string str)
        {
            List<string> list = new List<string>();
            int pos = str.IndexOf(" ");
            list.Add(str.Substring(0, pos));
            
            while (pos < str.Length -1)
            {
                while (str[++pos] == ' ')
                    continue;
                
                bool f = true;
                int endPos = pos;
                for (int i = pos; i < str.Length; i++)
                {
                    if (str[i] == '\"')
                    {
                        f = !f;
                    }

                    if (f && (str[i] == ' ' || i == str.Length - 1))
                    {
                        endPos = i;
                        break;
                    }
                }
                list.Add(str.Substring(pos, endPos - pos+1));
                pos = endPos;
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void Main(string[] args)
        {
            /*string str = "move /Library/Frameworks/Mono.framework/Versions/6.4.0/lib/ /Users/aleksandrtkacenko/Desktop/Колледж";
            int begin = str.IndexOf(' ');
            int last = str.LastIndexOf(' ');
            string command = str.Substring(0, begin);
            string source = str.Substring(begin, last-3);
            string destination = str.Substring(last);
            Console.WriteLine(command);
            Console.WriteLine(source);
            Console.WriteLine(destination);*/

            /*string str = "cd /Users/aleksandrtkacenko/Desktop/Pet Projects";
            int begin = str.IndexOf(' ');
            string source = str.Substring(0, begin);
            Console.WriteLine(source);
            
            foreach (var c in Enum.GetNames(typeof(Command)))
            {
                Console.WriteLine(c);
            }*/

            ConsoleManager consoleManager = new ConsoleManager();
            consoleManager.StartMenu();

            //string str = "copy   c:\\\"my folder\"\\project.exe  d:\\\"my target\"\\";
            //string str = "cd /Users/aleksandrtkacenko/Desktop/\"Project Projects/\"/\"DCERT IOS/\"DCERT";
            /*string str = "cd   Desktop";
            Console.WriteLine(str);
            Parse(str);*/

        }
    }
}