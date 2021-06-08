using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject
{
    internal class Program
    {
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

            
            
        }
    }
}