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
    [Table ("AssessmentTypes")]
    public class AssessmentType
    {
        [Key]
        public int AssessmentTypeID { get; set; }
        public string Name { get; set; }
    }
}
