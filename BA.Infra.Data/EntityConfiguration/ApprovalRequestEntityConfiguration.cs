using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ApprovalRequestEntityConfiguration : IEntityTypeConfiguration<ApprovalRequest>
    {
        public void Configure(EntityTypeBuilder<ApprovalRequest> builder)
        {
            builder.ToTable("ApprovalRequest", "UCAF");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.ApprovalRequestType)
                   .WithMany()
                   .HasForeignKey(a => a.ApprovalRequestTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.CreatedBy)
                   .WithMany()
                   .HasForeignKey(a => a.CreatedById)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Doctor)
                   .WithMany()
                   .HasForeignKey(a => a.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.PatientType)
                   .WithMany()
                   .HasForeignKey(a => a.PatientTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Company)
                   .WithMany()
                   .HasForeignKey(a => a.CompanyId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
