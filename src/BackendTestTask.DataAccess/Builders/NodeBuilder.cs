using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Builders;
public static class NodeBuilder
{
    public static Node Build(Guid treeId, string name, Guid? parentNodeId)
    {
        return new Node
        {
            Id = Guid.NewGuid(),
            TreeId = treeId,
            Name = name,
            ParentNodeId = parentNodeId
        };
    }
}
