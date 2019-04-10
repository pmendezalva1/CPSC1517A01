using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace FSISSystem.PMend.Data
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required(ErrorMessage ="Team name is required!")]
        [StringLength(50,ErrorMessage ="Team name can only be 50 characters long.")]
        public string TeamName { get; set; }
        [Required(ErrorMessage ="Coach's name is required!")]
        [StringLength(75,ErrorMessage ="Coach's name can only be 75 characters long.")]
        public string Coach { get; set; }
        [Required(ErrorMessage ="Assistant coach's name is required!")]
        [StringLength(75, ErrorMessage = "Assistant coach's name can only be 75 characters long.")]
        public string AssistantCoach { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
    }
}
