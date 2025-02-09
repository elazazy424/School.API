using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Infastructure.Configurations
{
    public class DepartmentSubjectConfig : IEntityTypeConfiguration<DepartmentSubject>
    {


        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.DID });

            builder.HasOne(ds => ds.Departments)
                .WithMany(d => d.DepartmentSubjects)
                .HasForeignKey(d => d.DID);

            builder.HasOne(ds => ds.Subjects)
                .WithMany(d => d.DepartmentSubjects)
                .HasForeignKey(d => d.SubID);
        }
    }
}
