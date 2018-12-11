using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ApprovalRequestProcessReleaseEntityConfiguration : IEntityTypeConfiguration<ApprovalRequestProcessRelease>
    {
        public void Configure(EntityTypeBuilder<ApprovalRequestProcessRelease> builder)
        {
            builder.ToTable("ApprovalRequestProcessRelease", "UCAF");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.AssignToEmployee)
                   .WithMany()
                   .HasForeignKey(a => a.AssignToEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.CurrentProcessOwner)
                   .WithMany()
                   .HasForeignKey(a => a.CurrentProcessOwnerId)
                   .OnDelete(DeleteBehavior.Restrict);
         

            builder.HasOne(a => a.ReleasedByEmployee)
                   .WithMany()
                   .HasForeignKey(a => a.ReleasedByEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
