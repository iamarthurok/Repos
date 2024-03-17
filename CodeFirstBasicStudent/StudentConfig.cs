using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudActivDynamicDB
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.StudentName)
                .IsRequired()
                .HasMaxLength(100);

            // Define validation rule for Height property: minimum value should be 120 and maximum value should be 300
            builder.Property(s => s.Height)
                .HasAnnotation("MinValue", 120)
                .HasAnnotation("MaxValue", 300)
                .IsRequired(false);

            // Define validation rule for Weight property: minimum value should be 20 and maximum value should be 200
            builder.Property(s => s.Weight)
                .HasAnnotation("MinValue", 20)
                .HasAnnotation("MaxValue", 200)
                .IsRequired(false);

            builder.Property(s => s.RowVersion)
                .IsRequired();
        }
    }
}
