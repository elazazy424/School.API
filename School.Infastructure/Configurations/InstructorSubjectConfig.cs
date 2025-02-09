using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Infastructure.Configurations
{
    public class InstructorSubjectConfig : IEntityTypeConfiguration<InstructorSubject>
    {
        public void Configure(EntityTypeBuilder<InstructorSubject> builder)
        {
            builder.HasKey(x => new { x.SubId, x.InsId });

            builder.HasOne(ds => ds.instructor)
                .WithMany(d => d.InsSubjects)
                .HasForeignKey(ds => ds.InsId);

            builder.HasOne(ds => ds.subjects)
                .WithMany(d => d.InstructorSubjects)
                .HasForeignKey(ds => ds.SubId);
        }
    }
}
