using System;
using System.Diagnostics;

namespace Bandersnatch
{
    class Program
    {

        static int Main(string[] args)
        {
            int l = args.Length;
            
            string path = args[0]; //args[0];
            Graph graph = Parser.createGraph(path);
            
            if (l > 2)
                return 1;
            else
            {
                if (!graph.CheckIntegrity())
                    return 3;
            }
            
            Player play = new Player(graph);
            
            if (args.Length > 1)
            {
                try
                {
                    play.LoadSave(args[1]);
                    play.Game();
                }
                catch (Exception a)
                {
                    return 4;
                }
            }
            try // lancer le program
            {
                
                play.Game();
                return 0;
            }
            catch (Exception b)
            {
                return 2;
            }
            

        }
    }
}