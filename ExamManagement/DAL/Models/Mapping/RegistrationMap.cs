using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class RegistrationMap : EntityTypeConfiguration<Registration>
    {
        public RegistrationMap()
        {
            // Primary Key
            this.HasKey(t => t.Rid);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Department)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(50);

            this.Property(t => t.Image)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(50);

            this.Property(t => t.Role)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Registration");
            this.Property(t => t.Rid).HasColumnName("Rid");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Department).HasColumnName("Department");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Role).HasColumnName("Role");
        }
    }
}
