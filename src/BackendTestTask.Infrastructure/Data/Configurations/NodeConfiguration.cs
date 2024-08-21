using BackendTestTask.Core.Entities;
using BackendTestTask.Infrastructure.Data.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTestTask.Infrastructure.Data.Configurations;

public class NodeConfiguration : IEntityTypeConfiguration<Node>
{
    public void Configure(EntityTypeBuilder<Node> builder)
    {
        builder.HasKey(node => node.Id);
        builder.Property(node => node.Id).ValueGeneratedOnAdd();

        builder.Property(node => node.Name).IsRequired();
        builder.Property(node => node.ParentNodeId).IsRequired(false);

        builder.HasOne(node => node.Tree).WithMany(tree => tree.Nodes).HasForeignKey(node => node.TreeId);
        builder
            .HasMany(node => node.ChildNodes)
            .WithOne(childNode => childNode.ParentNode)
            .HasForeignKey(childNode => childNode.ParentNodeId);

        builder.ToTable(ConfigurationConstants.TableNames.Nodes);
    }
}
