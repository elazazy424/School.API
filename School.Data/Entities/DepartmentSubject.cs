﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class DepartmentSubject
    {
        [Key]
        public int DeptSubId { get; set; }
        public int DID { get; set; }
        public int SubID { get; set; }
        [ForeignKey("DID")]
        public virtual Department? Departments { get; set; }
        [ForeignKey("SubID")]
        public virtual Subject? Subjects { get; set; }
    }
}
