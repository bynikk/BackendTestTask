using BackendTestTask.DataAccess.Data.Constants;
using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTestTask.DataAccess.Data.Configurations;

public class TreeConfiguration : IEntityTypeConfiguration<Tree>
{
    public void Configure(EntityTypeBuilder<Tree> builder)
    {
        builder.HasKey(tree => tree.Id);
        builder.Property(tree => tree.Id).ValueGeneratedOnAdd();

        builder.Property(tree => tree.Name).IsRequired();

        builder.HasMany(tree => tree.Nodes).WithOne(node => node.Tree).HasForeignKey(node => node.TreeId);

        builder.ToTable(ConfigurationConstants.TableNames.Trees);
    }
}
