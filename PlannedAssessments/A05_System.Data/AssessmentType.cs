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
        [Required(ErrorMessage ="Name is required!")]
        [StringLength(50, ErrorMessage ="Name is limited to 50 characters.")]
        public string Name { get; set; }
    }
}
