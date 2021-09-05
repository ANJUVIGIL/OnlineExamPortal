using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class QuestionXDurationMap : EntityTypeConfiguration<QuestionXDuration>
    {
        public QuestionXDurationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("QuestionXDuration");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegistrationId).HasColumnName("RegistrationId");
            this.Property(t => t.TestXQuestionId).HasColumnName("TestXQuestionId");
            this.Property(t => t.RequestTime).HasColumnName("RequestTime");
            this.Property(t => t.LeaveTime).HasColumnName("LeaveTime");
            this.Property(t => t.AnsweredTime).HasColumnName("AnsweredTime");

            // Relationships
            this.HasRequired(t => t.ExamRegistration)
                .WithMany(t => t.QuestionXDurations)
                .HasForeignKey(d => d.RegistrationId);
            this.HasRequired(t => t.TestXQuestion)
                .WithMany(t => t.QuestionXDurations)
                .HasForeignKey(d => d.TestXQuestionId);

        }
    }
}
