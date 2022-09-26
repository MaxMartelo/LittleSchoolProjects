using System;
using System.Collections.Generic;
using System.IO;

namespace Tiny42sh
{
    public static class Interpreter
    {
        static public string readline()
        {
            string input = Console.ReadLine();

            return input;
        }

        static public string[] parse_input(string input)
        {

            string[] splitInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            return splitInput;
        }

        static public Keyword is_keyword(string word)
        {
            Keyword res;
            foreach(Keyword k in Enum.GetValues<Keyword>())
            {
                if (word == k.ToString())
                    return k;
            }
            return Keyword.NOT_A_KEYWORD;
        }
    }

    public enum Keyword
    {
        ls, 
        cd, 
        cat, 
        touch, 
        rm, 
        mkdir, 
        pwd, 
        clear,
        NOT_A_KEYWORD
    }
}