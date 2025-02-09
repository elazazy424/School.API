using School.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        [MaxLength(200, ErrorMessage = "Can't be more than 200 characters")]
        public string? Address { get; set; }

        [MaxLength(500, ErrorMessage = "Can't be more than 500 characters")]
        public string? Phone { get; set; }

        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department? Department { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}
