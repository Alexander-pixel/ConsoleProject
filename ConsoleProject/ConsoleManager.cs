using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleProject
{
    public class ConsoleManager
    {
        private DirectoryInfo _directoryInfo;
        private ConsoleCommand _command;

        public DirectoryInfo CurrentDirectory
        {
            get => _directoryInfo;
            set => _directoryInfo = value;
        }

        public ConsoleManager()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            _directoryInfo = new DirectoryInfo(allDrives[0].ToString());
            _command = new ConsoleCommand();
        }

        public void StartMenu()
        {
            string input = String.Empty;
            while (true)
            {
                Console.Write($"{Directory.GetCurrentDirectory()}:  ");
                input = Console.ReadLine();
                List<string> list = _command.Parse(input);
                MakeAction(list);
                Console.WriteLine();
            }
        }

        private void MakeAction(List<string> list)
        {
            if (list != null)
            {
                switch (list[0])
                {
                    case "cd":
                        CdMethod(list[1]);
                        break;
                    case "cls":
                        CLSMethod();
                        break;
                    case "help":
                        HelpMethod();
                        break;
                    case "dir":
                        DirMethod();
                        break;
                    case "mkdir":
                        MkdirMethod(list[1]);
                        break;
                    case "rmdir":
                        RmdirMethod(list[1]);
                        break;
                    case "exit":
                        ExitMethod();
                        break;
                    case "copy":
                        CopyMethod(list[1], list[2]);
                        break;
                    case "touch":
                        TouchMethod(list[1]);
                        break;
                    case "cat":
                        CatMethod(list[1]);
                        break;
                    case "find":
                        FileSearchByName(list[1], new DirectoryInfo("."));
                        break;
                    default:
                        break;
                }
            }
            
        }

        public void HelpMethod()
        {
            Console.WriteLine("Type cls to clear console");
            Console.WriteLine("Type dir to see containing");
            Console.WriteLine("Type cd + folder name to move");
            Console.WriteLine("Type copy + folder name to copy");
            Console.WriteLine("Type del + folder name to delete");
            Console.WriteLine("Type mkdir + folder name to create");
        }

        public void CLSMethod()
        {
            Console.Clear();
        }

        public void DirMethod()
        {
            try
            {
                Console.WriteLine($"{"Name",-15}      {"Time",-10}       Length");
                foreach (var d in _directoryInfo.GetDirectories())
                {
                    Console.WriteLine($"{d.Name,-15}  DIR {d.CreationTime.ToShortTimeString(),-10}");
                }
                foreach (var f in _directoryInfo.GetFiles())
                {
                    Console.WriteLine($"{f.Name,-15} {f.Extension,4} {f.CreationTime.ToShortTimeString(),-10} {f.Length / 1024.0:0.00} KB");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        public void CdMethod(string obj)
        {
            try
            {
                /*Regex pattern = new Regex(@"^[/][A-Za-z]+");
                bool match = pattern.IsMatch(obj);
                */
                
                Directory.SetCurrentDirectory(obj);
                _directoryInfo = new DirectoryInfo(".");
                
                /*if (!match)
                {
                    //Console.WriteLine($"{_directoryInfo.Name}");
                    
                    _directoryInfo = new DirectoryInfo($"{_directoryInfo.FullName}\\{obj}\\");
                }
                else
                {
                    _directoryInfo = new DirectoryInfo($"{obj}\\");
                }*/
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public void CopyMethod(string source, string dest)
        {
            try
            {
                _directoryInfo = new DirectoryInfo(source);
                DirectoryInfo destination = new DirectoryInfo(dest);
            
                if (!Directory.Exists(destination.Name))
                {
                    Directory.CreateDirectory(destination.Name);
                }
                String[] files = Directory.GetFiles(_directoryInfo.Name);
                String[] directories = Directory.GetDirectories(_directoryInfo.Name);
                foreach (string s in files)
                {
                    File.Copy(s, Path.Combine(destination.Name, Path.GetFileName(s)), true);     
                }
                foreach(string d in directories)
                {
                    Directory.Move(Path.Combine(_directoryInfo.Name, Path.GetFileName(d)), Path.Combine(destination.Name, Path.GetFileName(d)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void DelMethod(string file, DirectoryInfo directoryInfo)
        {
            DirectoryInfo startDirectory = new DirectoryInfo("/Users/aleksandrtkacenko/Desktop");

            foreach (string f in Directory.GetFiles(startDirectory.Name))
            {
                Console.WriteLine(f);
            }

            foreach (string d in Directory.GetDirectories(startDirectory.Name))
            {
                DelMethod(file, new DirectoryInfo(d));
            }
        }

        public void RmdirMethod(string obj)
        {
            try
            {
                Regex pattern = new Regex(@"^[A-Za-z]:\\");
                bool match = pattern.IsMatch(obj);

                if (!match)
                {
                    //Console.WriteLine(_directoryInfo.FullName);
                    DirectoryInfo dir = new DirectoryInfo($"{_directoryInfo.FullName}\\{obj}");
                    dir.Delete();
                }
                else
                {
                    //Console.WriteLine(_directoryInfo.FullName);
                    DirectoryInfo directoryinfo = new DirectoryInfo($"{obj}");
                    directoryinfo.Delete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public void MkdirMethod(string obj)
        {
            try
            {
                Regex pattern = new Regex(@"^[A-Za-z]:\\");
                bool match = pattern.IsMatch(obj);

                if (!match)
                {
                    //Console.WriteLine(_directoryInfo.FullName);
                    DirectoryInfo dir = new DirectoryInfo($"{_directoryInfo.FullName}\\{obj}");
                    dir.Create();
                }
                else
                {
                    //Console.WriteLine(_directoryInfo.FullName);
                    DirectoryInfo directoryinfo = new DirectoryInfo($"{obj}");
                    directoryinfo.Create();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        public void MoveMethod(FileInfo file, DirectoryInfo destination)
        {
            if (Directory.Exists(destination.Name))
                File.Move(file.Name, destination.Name);
        }
        
        public void MoveMethod(DirectoryInfo source, DirectoryInfo destination)
        {
            if (Directory.Exists(destination.Name))
                source.MoveTo(destination.Name);
        }

        public void ExitMethod()
        {
            Environment.Exit(-1);
        }

        public void TouchMethod(string name)
        {
            File.Create(name);
        }

        public void CatMethod(string name)
        {
            try
            {
                Console.WriteLine(File.ReadAllText(name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Attrib(string name)
        {
            try
            {
                var arr = File.GetAttributes(name);
                Console.WriteLine(arr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public void FileSearchByName(string str, DirectoryInfo obj)
        {
            try
            {
                Regex regex = new Regex(str, RegexOptions.IgnoreCase);

                foreach (var file in obj.GetFiles())
                {
                    if(regex.IsMatch(file.Name))
                        Console.WriteLine(file.Name);
                }

                foreach (var d in obj.GetDirectories())
                {
                    FileSearchByName(str, d);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}