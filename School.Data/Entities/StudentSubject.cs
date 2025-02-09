using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class StudentSubject
    {
        [Key]
        public int StudSubjId { get; set; }
        public int StudId { get; set; }
        public int SubId { get; set; }
        [ForeignKey("StudId")]
        public virtual Student? student { get; set; }
        [ForeignKey("SubId")]
        public virtual Subject? subject { get; set; }
    }
}
