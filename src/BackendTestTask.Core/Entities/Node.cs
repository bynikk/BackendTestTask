namespace BackendTestTask.Core.Entities;

public class Node
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid TreeId { get; set; }
    public Tree? Tree { get; set; }

    public Guid? ParentNodeId { get; set; }
    public Node? ParentNode { get; set; }

    public List<Node> ChildNodes { get; set; } = new List<Node>();
}
