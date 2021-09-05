using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Qid);

            // Properties
            this.Property(t => t.QuestionType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Question1)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Question");
            this.Property(t => t.Qid).HasColumnName("Qid");
            this.Property(t => t.QCid).HasColumnName("QCid");
            this.Property(t => t.QuestionType).HasColumnName("QuestionType");
            this.Property(t => t.Question1).HasColumnName("Question");
            this.Property(t => t.ExhibitId).HasColumnName("ExhibitId");
            this.Property(t => t.points).HasColumnName("points");
            this.Property(t => t.isactive).HasColumnName("isactive");

            // Relationships
            this.HasOptional(t => t.Exhibit)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.ExhibitId);
            this.HasRequired(t => t.QuestionCategory)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.QCid);

        }
    }
}
