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
        public string Name { get; set; }
        public int? AssessmentTypeID { get; set; }
        public string Description { get; set; }
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
        public bool RequiredPass { get; set; }
    }
}
