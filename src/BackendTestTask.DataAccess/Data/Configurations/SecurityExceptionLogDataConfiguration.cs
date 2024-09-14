using BackendTestTask.DataAccess.Data.Constants;
using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTestTask.DataAccess.Data.Configurations;
public class SecurityExceptionLogDataConfiguration : IEntityTypeConfiguration<SecurityExceptionLogData>
{
    public void Configure(EntityTypeBuilder<SecurityExceptionLogData> builder)
    {
        builder.HasKey(data => data.Id);
        builder.Property(data => data.Id).ValueGeneratedOnAdd();

        builder.Property(data => data.Message).IsRequired();

        builder.ToTable(ConfigurationConstants.TableNames.SecurityExceptionLogDataEntries);
    }
}
