namespace BackendTestTask.BusinessLogic.DTOs;

public class NodeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid TreeId { get; set; }
    public TreeDto? Tree { get; set; }

    public Guid? ParentNodeId { get; set; }
    public NodeDto? ParentNode { get; set; }

    public List<NodeDto> ChildNodes { get; set; } = new List<NodeDto>();
}
