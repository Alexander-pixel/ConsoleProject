using System;
using System.Collections.Generic;

namespace ConsoleProject
{
    public class ConsoleCommand
    {
        public List<string> Parse(string str)
        { 
            try
            {
                List<string> list = new List<string>();
                int pos = str.IndexOf(" ");
                list.Add(str.Substring(0, pos));

                while (pos < str.Length - 1)
                {
                    while (str[++pos] == ' ');

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
                
                    list.Add(str.Substring(pos, endPos - pos + 1));
                    pos = endPos;
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}