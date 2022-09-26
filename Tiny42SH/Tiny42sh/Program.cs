using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiny42sh
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = true;
            while (quit)
            {
                Console.Write("Tiny42sh ");
                string res = Interpreter.readline();
                if (res == "exit")
                    quit = false;
                else
                    //Console.WriteLine(Interpreter.parse_input(res));
                    Execution.execute_commad(Interpreter.parse_input(res));

            }
            
        }
    }
}
