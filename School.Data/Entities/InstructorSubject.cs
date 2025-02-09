using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class InstructorSubject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubId { get; set; }
        [ForeignKey(nameof(InsId))]
        public Instructor instructor { get; set; }
        [ForeignKey(nameof(SubId))]
        public Subject subjects { get; set; }
    }
}
