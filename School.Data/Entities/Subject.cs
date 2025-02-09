﻿using School.Data.Commons;

namespace School.Data.Entities
{
    public class Subject : GeneralLocalizableEntity
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int Period { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new List<DepartmentSubject>();
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new List<InstructorSubject>();
    }
}
