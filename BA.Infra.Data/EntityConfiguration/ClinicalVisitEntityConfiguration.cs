using BA.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.Infra.Data.EntityConfiguration
{
    public class ClinicalVisitEntityConfiguration : IEntityTypeConfiguration<ClinicalVisit>
    {
        public void Configure(EntityTypeBuilder<ClinicalVisit> builder)
        {

            builder.HasKey(e => e.Id)
                .ForSqlServerIsClustered(false);

            builder.HasIndex(e => e.DoctorId)
                .HasName("IX_ClinicalVisit_2");

            builder.HasIndex(e => e.Id)
                .HasName("IX_ClinicalVisit")
                .ForSqlServerIsClustered();

            builder.HasIndex(e => e.RegistrationNo)
                .HasName("RegNo");

            builder.HasIndex(e => e.ScheduleId)
                .HasName("IX_ClinicalVisit_4");

            builder.HasIndex(e => e.VisitDateTime)
                .HasName("IX_ClinicalVisit_3");

            builder.HasIndex(e => new { e.DoctorId, e.IssueAuthorityCode })
                .HasName("IX_ClinicalVisit_5");

            builder.HasIndex(e => new { e.DoctorId, e.RegistrationNo, e.IssueAuthorityCode })
                .HasName("IX_ClinicalVisit_7");

            builder.HasIndex(e => new { e.IssueAuthorityCode, e.RegistrationNo, e.Id })
                .HasName("IX_ClinicalVisit_1");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.AdmissionType)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.AdmittingInstructions)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            builder.Property(e => e.Bmi)
                .HasColumnName("BMI")
                .HasColumnType("numeric(18, 2)");

            builder.Property(e => e.DoctorId).HasColumnName("DoctorID");

            builder.Property(e => e.FinalDiagnosis)
                .HasMaxLength(6000)
                .IsUnicode(false);

            builder.Property(e => e.FollowUpDateTime).HasColumnType("datetime");

            builder.Property(e => e.Height).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.ImpVisit).HasColumnName("imp_visit");

            builder.Property(e => e.Ipid)
                .HasColumnName("IPID")
                .HasDefaultValueSql("(0)");

            builder.Property(e => e.IssueAuthorityCode)
                .HasMaxLength(6)
                .IsUnicode(false);

            builder.Property(e => e.ModifiedBy).HasDefaultValueSql(@"
create default space as  ' '



");

            builder.Property(e => e.ModifiedDateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql(@"
create default space as  ' '



");

            builder.Property(e => e.OperatorId)
                .HasColumnName("OperatorID")
                .HasDefaultValueSql(@"
create default space as  ' '



");

            builder.Property(e => e.OtherAdvice)
                .HasMaxLength(6000)
                .IsUnicode(false);

            builder.Property(e => e.ProvDiagnosis)
                .HasMaxLength(6000)
                .IsUnicode(false);

            builder.Property(e => e.ReasonForAdmission)
                .HasMaxLength(6000)
                .IsUnicode(false);

            builder.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

            builder.Property(e => e.SheetId).HasDefaultValueSql("(0)");

            builder.Property(e => e.StartDatetime).HasColumnType("datetime");

            builder.Property(e => e.TreatmentPlan).HasColumnType("text");

            builder.Property(e => e.VisitDateTime).HasColumnType("datetime");

            builder.Property(e => e.Weight).HasColumnType("numeric(18, 2)");

        }
    }
}
