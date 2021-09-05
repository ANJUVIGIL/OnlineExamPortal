using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class ExamRegistrationMap : EntityTypeConfiguration<ExamRegistration>
    {
        public ExamRegistrationMap()
        {
            // Primary Key
            this.HasKey(t => t.ExamId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ExamRegistration");
            this.Property(t => t.ExamId).HasColumnName("ExamId");
            this.Property(t => t.StudentId).HasColumnName("StudentId");
            this.Property(t => t.TestId).HasColumnName("TestId");
            this.Property(t => t.RegistrationDate).HasColumnName("RegistrationDate");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.TokenExpireTime).HasColumnName("TokenExpireTime");

            // Relationships
            this.HasRequired(t => t.Student)
                .WithMany(t => t.ExamRegistrations)
                .HasForeignKey(d => d.StudentId);
            this.HasRequired(t => t.Test)
                .WithMany(t => t.ExamRegistrations)
                .HasForeignKey(d => d.TestId);

        }
    }
}
