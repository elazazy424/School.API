using School.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Instructor : GeneralLocalizableEntity
    {
        [Key]
        public int Id { get; set; }
        public string? INameAr { get; set; }
        public string? INameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public int DID { get; set; }
        [ForeignKey(nameof(DID))]
        public Department department { get; set; }
        public Department departmentManager { get; set; }
        [ForeignKey(nameof(SupervisorId))]
        public Instructor supervisor { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public virtual ICollection<InstructorSubject> InsSubjects { get; set; } = new List<InstructorSubject>();
    }
}
