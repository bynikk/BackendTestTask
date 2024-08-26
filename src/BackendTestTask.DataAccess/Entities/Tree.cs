namespace BackendTestTask.DataAccess.Entities;

public class Tree
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Node> Nodes { get; set; } = new List<Node>();
}
