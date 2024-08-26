namespace BackendTestTask.API.Contracts.Requests;

public class CreateNodeRequest
{
    public Guid TreeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid? ParentNodeId { get; set; }
}
