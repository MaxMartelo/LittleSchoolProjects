namespace Bandersnatch;

public class Graph
{
    private readonly Dictionary<int, Node> nodes;

    public Graph()
    {
        nodes = new Dictionary<int, Node>();
    }

    public Node GetNode(int id) // return Node if the id is found, null otherwise 
    {

        if (nodes.ContainsKey(id))
            return  nodes[id];

        return null;
    }

    public bool AddNode(int id, Node node)
    {
        if (nodes.ContainsKey(id))
            return false;
        else
        {
            nodes.Add(id, node);
            return true;
        }
        
    }

    public int GetBegin()
    {
       
        foreach (var el in nodes)
        {
            if (el.Value.getType() == NodeType.Begin)
                return el.Key;
        }
        
        return -1;
    }


    public bool CheckIntegrity()
    {
        int nbBeginNode = 0;
        int nbEndNode = 0;
        foreach (var el in nodes)
        {
            if (el.Value.getType() == NodeType.Begin)
            {
                nbBeginNode += 1;
                if (nbBeginNode > 1)
                    return false;
            }
                
            else if (el.Value.getType() == NodeType.End)
                nbEndNode += 1;
            el.Value.GetNeighbours();

        }
        if (nbEndNode == 0)
            return false;
        else
            return true;
        // index du voisin pointe vers un noeud existant
    }
    
    
    
    
}