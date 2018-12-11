using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ApprovalRequestItemEntityConfiguration : IEntityTypeConfiguration<ApprovalRequestItem>
    {
        public void Configure(EntityTypeBuilder<ApprovalRequestItem> builder)
        {
            builder.ToTable("ApprovalRequestItem", "UCAF");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.ApprovalRequestItemStatus)
                   .WithMany()
                   .HasForeignKey(a => a.ApprovalRequestItemStatusId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.CreatedBy)
                   .WithMany()
                   .HasForeignKey(a => a.CreatedById)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
