using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class ChoiceMap : EntityTypeConfiguration<Choice>
    {
        public ChoiceMap()
        {
            // Primary Key
            this.HasKey(t => t.ChoiceId);

            // Properties
            this.Property(t => t.Label)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Choice");
            this.Property(t => t.ChoiceId).HasColumnName("ChoiceId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.Label).HasColumnName("Label");
            this.Property(t => t.points).HasColumnName("points");
            this.Property(t => t.isactive).HasColumnName("isactive");

            // Relationships
            this.HasRequired(t => t.Question)
                .WithMany(t => t.Choices)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
