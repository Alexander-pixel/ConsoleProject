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
            // move copy rename
            try
            {
                //int pos = str.IndexOf(' ');
                //string command = str.Substring(0, str.Length);

                if (/*IsCorrect(command)*/IsCorrect(str))
                {
                    _command = (Command) Enum.Parse(typeof(Command), str);
                    //_command = (Command) Enum.Parse(typeof(Command), command);
                    if(_command != Command.cls && _command != Command.help)
                        _attributes.Add(GetAddress(str));
                }
                else
                {
                    throw new ArgumentException("Wrong command input.");
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
                    //Console.WriteLine(c);
                    return true;
                }
            }
            return false;
        }
        
    }
}