namespace BackendTestTask.BusinessLogic.DTOs;

public class TreeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<NodeDto> Nodes { get; set; } = new List<NodeDto>();
}
