using BackendTestTask.DataAccess.Entities;

namespace BackendTestTask.DataAccess.Builders;
public class TreeBuilder
{
    public static Tree Build(string name)
    {
        return new Tree
        {
            Id = Guid.NewGuid(),
            Name = name,
        };
    }
}
