using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Infastructure.Configurations
{
    public class StudentSubjectConfig : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(x => new { x.SubId, x.StudId });

            builder.HasOne(ds => ds.student)
                .WithMany(d => d.StudentSubjects)
                .HasForeignKey(ds => ds.StudId);

            builder.HasOne(ds => ds.subject)
               .WithMany(d => d.StudentSubjects)
               .HasForeignKey(ds => ds.SubId);
        }
    }
}
