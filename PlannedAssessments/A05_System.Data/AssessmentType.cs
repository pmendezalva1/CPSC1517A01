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
    [Table("AssessmentTypes")]
    public class AssessmentType
    {
        [Key]
        public int AssessmentTypeID { get; set; }
        public string Name { get; set; }
    }
}
