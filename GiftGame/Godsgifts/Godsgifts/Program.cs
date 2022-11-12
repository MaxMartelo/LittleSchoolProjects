using System;

namespace Godsgifts
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter offringsToWrite = new StreamWriter("config.txt"))
            {
                offringsToWrite.WriteLine(0);
                offringsToWrite.WriteLine("Fruits");
                offringsToWrite.WriteLine(50);
                offringsToWrite.WriteLine(1);
                offringsToWrite.WriteLine("Humans");
                offringsToWrite.WriteLine(1000);
                offringsToWrite.WriteLine(2);
                offringsToWrite.WriteLine("Wine");
                offringsToWrite.WriteLine(100);
                offringsToWrite.WriteLine(3);
                offringsToWrite.WriteLine("Goat");
                offringsToWrite.WriteLine(500);
                offringsToWrite.WriteLine(4);
                offringsToWrite.WriteLine("Gold");
                offringsToWrite.Write(200);
            }

            string file = args[0]; // config.txt
            Offering[] offerings = Results.InitOfferings(file, uint.Parse(args[1])); // Init all the offering and 15 replaced by arge[2]
            Results results = new Results(args[2], offerings); // Maxime replaced by args[3]
            
            
            string command = "";
            while (command != "quit") // to read the input until quitting 
            {
                command = Console.ReadLine();
                Console.Clear();
                if (command == "unbox")
                     Results.UpdateResults(offerings, ref results); //pick a reward 
                if(command == "info") 
                    Results.PrintInfo(results); // list of the earnings
                else if(command == "list")
                    Results.PrintRewards(offerings); // list of possible rewards
                else if (command == "help")
                    Console.WriteLine("Allowed command are : \n unbox \n info \n list \n quit");
                else if (command == "quit")
                    Results.SaveResults(results);

            }
            
            
        }
    }
}