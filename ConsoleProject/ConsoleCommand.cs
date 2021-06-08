using System;
using System.Collections.Generic;

namespace ConsoleProject
{
    public class ConsoleCommand
    {
        private Command _command;
        private List<string> _attributes;

        public Command Command
        {
            get => _command;
            set => _command = value;
        }

        public List<string> GetAttributes()
        {
            return _attributes;
        }
        
        public ConsoleCommand()
        {
            _attributes = new List<string>();
        }
        
        private string GetAddress(string str)
        {
            try
            {
                int begin = str.IndexOf(' ')+1;
                string source = str.Substring(begin);
                return source;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public void Parse(string str)
        {
            try
            {
                int pos = str.IndexOf(' ');
                string command = String.Empty;
                if (pos != -1)
                {
                    command = str.Substring(0, pos);
                    if (IsCorrect(command))
                    {
                        _command = (Command) Enum.Parse(typeof(Command), command);
                        Console.WriteLine(_command);
                        _attributes.Clear();
                        _attributes.Add(GetAddress(str));
                        Console.WriteLine(_attributes[0]);
                    }
                    else
                    {
                        throw new ArgumentException("Wrong command input.");
                    }
                }
                else
                {
                    Console.WriteLine("We are here.");
                    if (str == Command.dir.ToString() || str == Command.cls.ToString() ||
                        str == Command.help.ToString())
                        command = str;
                    _command = (Command) Enum.Parse(typeof(Command), command);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private bool IsCorrect(string command)
        {
            foreach (var c in Enum.GetNames(typeof(Command)))
            {
                if (c == command)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}