using BackendTestTask.DataAccess.Data.Constants;
using BackendTestTask.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTestTask.DataAccess.Data.Configurations;

public class SecurityExceptionLogConfiguration : IEntityTypeConfiguration<SecurityExceptionLog>
{
    public void Configure(EntityTypeBuilder<SecurityExceptionLog> builder)
    {
        builder.HasKey(log => log.Id);
        builder.Property(log => log.Id).ValueGeneratedOnAdd();

        builder.Property(log => log.ExceptionName).IsRequired();
        builder.Property(log => log.CorrelationId).IsRequired();
        builder.Property(log => log.DataId).IsRequired();

        builder.HasOne(log => log.Data).WithMany().HasForeignKey(log => log.DataId);

        builder.Property(log => log.CreatedAtUtc).HasDefaultValueSql(ConfigurationConstants.GetGurrentTimeFunction);

        builder.ToTable(ConfigurationConstants.TableNames.SecurityExceptionLogs);
    }
}
