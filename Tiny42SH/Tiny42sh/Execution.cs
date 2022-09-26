using System;
using System.IO;
using static Tiny42sh.Keyword;
using static System.IO.Directory;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace Tiny42sh
{
    public static class Execution
    {
        static public int execute_commad(string[] cmd)
        {
            foreach (string s in cmd)
            {
                switch (Interpreter.is_keyword(s))
                {
                    case ls:
                        return execute_ls(cmd);
                    case cd:
                        return execute_cd(cmd);
                    case cat:
                        return execute_cat(cmd);
                    case touch:
                        return execute_touch(cmd);
                    case rm:
                        return execute_rm(cmd);
                    case mkdir:
                        return execute_mkdir(cmd);
                    case pwd:
                        return execute_pwd(cmd);
                    case clear:
                        return execute_clear(cmd);
                    default:
                        return 1;
                }
            }

            return 0; // case never reached
        }


        static public string splitting(string path)
        {
            string[] splittedPath = path.Split('\\'); // to change in / for linux
            int len = splittedPath.Length;
            return splittedPath[len - 1];
        }

        static private int execute_ls(string[] cmd)
        {
            int len = cmd.Length;
            if (len == 1)
            {
                foreach (var files in EnumerateFileSystemEntries("."))
                {
                    if (Directory.Exists($"{files.Remove(0, 2)}"))
                    {
                        Console.WriteLine($"{files.Remove(0, 2)}" + "/");
                    }
                    else
                    {
                        Console.WriteLine($"{files.Remove(0, 2)}");
                    }
                }

                return 0;

            }
            else
            {
                string cur = "";
                string el = "";
                for (int i = 1; i < len; i++)
                {
                    cur = cmd[i];
                    el = cmd[i];
                    // if (i > 1)
                    //     cur += ".\\" + cmd[i];
                    // else 
                    // cur += cmd[i];
                    if (Directory.Exists(cur))
                    {
                        foreach (var files in EnumerateFileSystemEntries(".\\" + cur)) //To do, replace by /
                        {
                            string file = $"{files.Remove(0, 2)}";
                            string res = splitting(file);
                            Console.WriteLine(res);
                        }
                    }
                    else if (File.Exists(cur))
                    {
                        Console.WriteLine(cur);
                    }
                    else
                    {
                        return 1;
                    }
                    // if ((Directory.GetParent($"{files.Remove(0, 0)}")).Name == el) // check if what is after the ls is a directory
                    // {
                    //     if (Directory.Exists($"{files.Remove(0,2)}"))
                    //         Console.WriteLine($"{files.Remove(0,el.Length + 3)}" + "/");
                    //     else
                    //         Console.WriteLine($"{files.Remove(0,el.Length + 3)}");
                    // }
                    // else if (File.Exists($"{files.Remove(0,2)}"))
                    // {
                    //     Console.WriteLine(el);
                    // }
                    // else
                    // {
                    //     return 1;
                    // }
                }

                return 0;
            }
        }


        static private int execute_cd(string[] cmd)
        {
            int len = cmd.Length;
            if (len == 1)
            {
                return 0;
            }

            else if (cmd[1] == "..")
            {
                string path = Directory.GetCurrentDirectory();
                string ParentPath = System.IO.Directory.GetParent(path).FullName;
                Directory.SetCurrentDirectory(ParentPath);
                return 0;
            }

            else if (cmd.Length == 2)
            {
                string path = Directory.GetCurrentDirectory();
                string el = cmd[1];
                foreach (var d in Directory.GetDirectories(path))
                {
                    var dir = new DirectoryInfo(d);
                    if (dir.Name == el) // check if the directory name correspond to what is after the cd
                    {
                        Directory.SetCurrentDirectory(path + ".\\" + el);
                        return 0;
                    }
                }

                return 1; // case where the arg does not correspond to a directory
            }
            else
                return 0; // case where there are too many arg

        }


        static private int execute_cat(string[] cmd)
        {
            int l = cmd.Length;

            if (l > 2 || l == 0)
                return 1; // case where too many args
            else
            {
                string path = Directory.GetCurrentDirectory();
                string el = cmd[1];

                if (File.Exists(path + ".\\" + el + ".txt"))
                {
                    using (StreamReader reader = new StreamReader(path + ".\\" + el + ".txt"))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }

                    return 0;
                }

                return 1;
            }
        }

        static private int execute_touch(string[] cmd)
        {
            int l = cmd.Length;
            if (l > 2 || l == 0)
                return 1;
            else
            {
                string path = Directory.GetCurrentDirectory();
                string el = cmd[1];

                if (File.Exists(path + ".\\" + el))
                {
                    File.SetLastAccessTime(path + ".\\" + el, DateTime.Now);

                    return 0;
                }
                else
                {
                    File.Create(path + ".\\" + el);
                    return 0;
                }
            }
        }

        static private int execute_rm(string[] cmd)
        {
            int l = cmd.Length;
            if (l > 2 || l == 0)
                return 1;

            string path = Directory.GetCurrentDirectory();
            string el = cmd[1];

            if (File.Exists(Path.Combine(path, el)))
            {
                File.Delete(Path.Combine(path, el));
                return 0;
            }

            else
                return 1;

        }

        static private int execute_mkdir(string[] cmd)
        {
            int l = cmd.Length;
            if (l > 2 || l == 0)
                return 1;
            else
            {
                string dirName = cmd[1];
                string path = Directory.GetCurrentDirectory();
                if (!Directory.Exists(Path.Combine(path, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(path, dirName));
                    return 0;
                }

                return 1;
            }

        }

        static private int execute_pwd(string[] cmd)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            return 0;
        }

        static private int execute_clear(string[] cmd)
        {
            Console.Clear();
            return 0;
        }

        static private int execute_man(string[] cmd)
        {
            throw new NotImplementedException("Nothing done yet in Method "
                                              + MethodBase.GetCurrentMethod().ReflectedType.Name
                                              + MethodBase.GetCurrentMethod().Name);
        }
    }
}
    
