using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace FormA.Data
{
    [Table("PlannedAssessments")]
    public class PlannedAssessments
    {
        [Key]
        public int AssessmentID { get; set; }
        public string Name { get; set; }
        public int? AssessmentTypeID { get; set; }
        public string Description { get; set; }
        public int? CourseID { get; set; }
        public int Weight { get; set; }
        public bool RequiredPass { get; set; }
        public string LastModified { get; set; }
    }
}
