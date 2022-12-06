namespace Bandersnatch;

public class Node
{
    private readonly string _message;
    private readonly Dictionary<int, string> _neighbours;
    private readonly NodeType _type;

    public Node(string message, NodeType type)
    {
        _message = message ;
        _type = type;
        _neighbours = new Dictionary<int, string>(); // no neighbours at the beginning

    }

    public string GetMessage() => _message;


    public NodeType getType() => _type;

    public Dictionary<int, string> GetNeighbours() => _neighbours;
}

public enum NodeType
{
    Begin = 1,
    End = 2,
    Middle = 0
}