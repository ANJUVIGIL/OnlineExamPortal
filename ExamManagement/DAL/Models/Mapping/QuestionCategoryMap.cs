using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class QuestionCategoryMap : EntityTypeConfiguration<QuestionCategory>
    {
        public QuestionCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Cid);

            // Properties
            this.Property(t => t.Category)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("QuestionCategory");
            this.Property(t => t.Cid).HasColumnName("Cid");
            this.Property(t => t.Category).HasColumnName("Category");
        }
    }
}
