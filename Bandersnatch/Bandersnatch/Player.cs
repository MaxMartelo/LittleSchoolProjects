using System.Xml.Xsl;

namespace Bandersnatch;

public class Player
{
    private readonly Stack<int> history;
    private int index;
    private readonly Graph story;

    public Player(Graph story)
    {
        this.story = story;
        index = story.GetBegin();
        this.history = new Stack<int>();
    }

    private int GetNextAction()
    {
        
        Node actualNode = story.GetNode(index); // get the current node
        Console.WriteLine(actualNode.GetMessage()); // print the message of the current node
        (int,int) cursPos = Console.GetCursorPosition();
        int nbNeighbours = actualNode.GetNeighbours().Count;
        int posIni = cursPos.Item2; // get under the line
        if (nbNeighbours == 0) // if no neighbours, retunrn -1
            return -1;
        else
        {
            List<int> myIDList = new List<int>();
            int nbN = posIni;
            foreach (var el in actualNode.GetNeighbours()) // print each 
            {
                myIDList.Add(el.Key);
                Console.WriteLine(("  " + el.Value));
                nbN += 1;
            }

            
            
            posIni = cursPos.Item2; // get under the line
            int posActual = posIni;
            Console.SetCursorPosition(0, posIni);
            Console.Write(">");
            while (true)
            {
                Console.SetCursorPosition(0, posActual);

                ConsoleKeyInfo cki = Console.ReadKey(); // to read input
                if (cki.Key == ConsoleKey.Q) // Q to quit the program 
                    return -1;

                if (cki.Key == ConsoleKey.UpArrow) 
                {
                    Console.Write("\b"); // to delete the previous cursor
                    if (posActual - 1 == 0 || posActual - 1 == posIni - 1)
                        posActual = nbN;
                    Console.SetCursorPosition(0, posActual -= 1);
                    Console.Write(">");
                }


                if (cki.Key == ConsoleKey.DownArrow) 
                {
                    Console.Write("\b");
                    if (posIni > 1)
                    {
                        if (posActual + posIni > nbN)
                            posActual = posIni - 1;
                    }
                    else // posIni = 1
                    {
                        if (posActual + posIni >= nbN) // attention le > marche mais 1 en plus et le >= ne marche pas pour le cas speciale
                            posActual = posIni - 1;
                        
                    }
                    Console.SetCursorPosition(0, posActual += 1);
                    Console.Write(">");
                }
                
                if (cki.Key == ConsoleKey.Enter)
                {
                    history.Push(index);// the Index of the node 
                    return myIDList[posActual - posIni]; // my list start at 0 while my arrow start at posIni => top - posIni 
                }

                if (cki.Key == ConsoleKey.B)// if B, return the previsou node
                {
                    return history.Pop();
                }
                if (cki.Key == ConsoleKey.S)// if B, return the previsou node
                {
                    string res = "";
                    foreach (var el in history)
                    {
                        string nb = el.ToString();
                        int repetition = nbElts(nb);
                        res = res + repetition + el;
                    }

                    using (StreamWriter file = new StreamWriter("save.txt"))
                    {
                        file.Write(res);
                    }
                }
            }
        }
    }

    public int nbElts(string el)
    {
        int count = 0;
        foreach (var ele in el)
            count += 1;
        return count;
    }

    public bool LoadSave(string save)
    {
        using (StreamReader file = new StreamReader(save))
        {
            string res = file.ReadLine();
            string subres = "";
            int resum = 0;
            int len = res.Length;
            for (int i = 0; i < len; i++)
            {
                int count = res[i] - '0';; // - 0 is here to convert a char into an int 
                subres = "";
                for(int j = i + 1; j <= i+count; j++)
                {
                    subres += res[j];
                }

                if (history.Count == 0)
                    resum = Int32.Parse(subres);
                history.Push(Int32.Parse(subres));
                i += count;
            }
            index = resum;// get the last index 
        }

        return true;
    }

    public void Game()
    {
        Node actualNode = story.GetNode(index); // get the current node
        while (actualNode.getType() != NodeType.End)
        {
            Console.Clear();
            int nID = GetNextAction();
            actualNode = story.GetNode(nID);
            index = nID;
        }
        
        Console.WriteLine(actualNode.GetMessage());// print the last message
    }
    
}