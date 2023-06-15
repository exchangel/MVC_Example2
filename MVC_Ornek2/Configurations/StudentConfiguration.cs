using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Ornek2.Models;

namespace MVC_Ornek2.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(30);

            builder.Property(x => x.FirstName).IsRequired();
        }
    }
}
