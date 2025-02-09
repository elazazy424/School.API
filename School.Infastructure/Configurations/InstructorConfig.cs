using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Infastructure.Configurations
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder
                .HasOne(x => x.supervisor).WithMany(x => x.Instructors).HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
