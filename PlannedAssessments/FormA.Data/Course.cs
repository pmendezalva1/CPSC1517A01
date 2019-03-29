﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#endregion

namespace FormA.Data
{
    [Table("Courses")]
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public decimal? Credits { get; set; }
        public int? TotalHours { get; set; }
        public int? ClassroomType { get; set; }
        public int? Term { get; set; }
        public decimal? Tuition { get; set; }
        public string Description { get; set; }
    }
}
