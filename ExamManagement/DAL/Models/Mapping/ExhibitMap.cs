using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class ExhibitMap : EntityTypeConfiguration<Exhibit>
    {
        public ExhibitMap()
        {
            // Primary Key
            this.HasKey(t => t.Eid);

            // Properties
            this.Property(t => t.ExhibitData)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Exhibit");
            this.Property(t => t.Eid).HasColumnName("Eid");
            this.Property(t => t.ExhibitData).HasColumnName("ExhibitData");
        }
    }
}
