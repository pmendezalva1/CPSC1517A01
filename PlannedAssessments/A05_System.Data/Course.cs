using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace A05_System.Data
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public string CourseID { get; set; }
        [Required(ErrorMessage ="Course name is required!")]
        [StringLength(75, ErrorMessage ="Course Name is limited to 75 characters.")]
        public string CourseName { get; set; }
        public decimal? Credits { get; set; }
        public int? TotalHours { get; set; }
        public int? ClassroomType { get; set; }
        public int? Term { get; set; }
        public decimal? Tuition { get; set; }
        [Required(ErrorMessage ="Description is required!")]
        [StringLength(250, ErrorMessage ="Description is limited to 250 characters.")]
        public string Description { get; set; }
    }
}
