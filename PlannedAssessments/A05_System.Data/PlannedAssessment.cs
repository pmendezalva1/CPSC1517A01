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
    [Table("PlannedAssessments")]
    public class PlannedAssessment
    {
        private string _CourseID;
        [Key]
        public int AssessmentID { get; set; }
        [Required(ErrorMessage ="Name is required!")]
        [StringLength(50, ErrorMessage ="Name is limited to 50 characters.")]
        public string Name { get; set; }
        public int? AssessmentTypeID { get; set; }
        [Required(ErrorMessage ="Description is required!")]
        [StringLength(250, ErrorMessage ="Description is limited to 250 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Course ID is required!")]
        public string CourseID
        {
            get
            {
                return _CourseID;
            }
            set
            {
                _CourseID = string.IsNullOrEmpty(value) ? null : value;
            }

        }
        public Int16? Weight { get; set; }
        [Required(ErrorMessage ="Required pass must be set.")]
        public bool RequiredPass { get; set; }
    }
}
