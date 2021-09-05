using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class TestXPaperMap : EntityTypeConfiguration<TestXPaper>
    {
        public TestXPaperMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TestXPaper");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RegistrationId).HasColumnName("RegistrationId");
            this.Property(t => t.TestXQuestionId).HasColumnName("TestXQuestionId");
            this.Property(t => t.ChoiceId).HasColumnName("ChoiceId");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.MarkScored).HasColumnName("MarkScored");

            // Relationships
            this.HasRequired(t => t.Choice)
                .WithMany(t => t.TestXPapers)
                .HasForeignKey(d => d.ChoiceId);
            this.HasRequired(t => t.TestXQuestion)
                .WithMany(t => t.TestXPapers)
                .HasForeignKey(d => d.TestXQuestionId);

        }
    }
}
