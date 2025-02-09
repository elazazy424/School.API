using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Infastructure.Configurations
{
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NameAr).HasMaxLength(500);

            builder.HasMany(x => x.Students)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DeptId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.instructor)
                .WithOne(x => x.departmentManager)
                .HasForeignKey<Department>(x => x.InsManager)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
