using School.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public partial class Department : GeneralLocalizableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int InsManager { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new List<DepartmentSubject>();
        public virtual ICollection<Instructor> instructors { get; set; } = new List<Instructor>();

        [ForeignKey(nameof(InsManager))]
        public virtual Instructor instructor { get; set; }

    }
}
