namespace Bandersnatch;

public class Parser
{
    public static Graph createGraph(string filename)
    {
        try //send me a message if you read this 0782955461
        {
            using (StreamReader toRead = new StreamReader(filename)) // ID / Type / message / neighbour (int + message)
            {
                string line;
                Graph graph = new Graph();
                while ((line = toRead.ReadLine()) != null)
                {
                    if (!line.Contains("#") && line != "")
                    {
                        string[] elts = line.Split(':'); // elts[0] = ID, elts[1] = node type, elts[2] = message 
                        int l = elts.Length - 1; // -1 to avoid the type
                        Node node = new Node(elts[2], (NodeType)Int32.Parse(elts[1])); // message and type 

                        graph.AddNode(Int32.Parse(elts[0]), node); // ID and node

                        int i = 3;
                        int j = 4;

                        while (l - 2 >= 2)
                        {
                            node.GetNeighbours().Add(Int32.Parse(elts[i]), elts[j]); //ID and message
                            l -= 2;
                            i += 2;
                            j += 2;
                        }
                    }
                }
                return graph;
            }
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
}