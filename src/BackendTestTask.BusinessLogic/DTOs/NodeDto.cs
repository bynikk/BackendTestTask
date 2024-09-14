using System.Text.Json.Serialization;

namespace BackendTestTask.BusinessLogic.DTOs;

public class NodeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid TreeId { get; set; }

    [JsonIgnore]
    public TreeDto? Tree { get; set; }

    public Guid? ParentNodeId { get; set; }

    [JsonIgnore]
    public NodeDto? ParentNode { get; set; }

    public List<NodeDto> ChildNodes { get; set; } = new List<NodeDto>();
}
