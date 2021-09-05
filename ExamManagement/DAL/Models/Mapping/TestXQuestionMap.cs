using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class TestXQuestionMap : EntityTypeConfiguration<TestXQuestion>
    {
        public TestXQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TestXQuestion");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TestId).HasColumnName("TestId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.QuestionNumber).HasColumnName("QuestionNumber");
            this.Property(t => t.isactive).HasColumnName("isactive");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.TestXQuestions)
                .HasForeignKey(d => d.QuestionId);
            this.HasRequired(t => t.Test)
                .WithMany(t => t.TestXQuestions)
                .HasForeignKey(d => d.TestId);

        }
    }
}
