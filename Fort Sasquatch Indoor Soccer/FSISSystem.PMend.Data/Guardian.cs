using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion
namespace FSISSystem.PMend.Data
{
    [Table("Guardian")]
    public class Guardian
    {
        [Key]
        public int GuardianID { get; set; }
        [Required(ErrorMessage ="First name is required!")]
        [StringLength(50, ErrorMessage ="First name is limited to 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name is required!")]
        [StringLength(50, ErrorMessage = "Last name is limited to 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Emergency phone number is required!")]
        [StringLength(10, ErrorMessage = "Emergency phone number is limited to 10 characters.")]
        public string EmergencyPhoneNumber { get; set; }
        [Required(ErrorMessage ="Email address is required!")]
        [StringLength(75, ErrorMessage = "Email address is limited to 75 characters.")]
        public string EmailAddress { get; set; }

        [NotMapped]
        public string FullNamne
        {
            get { return LastName + " " + FirstName; }

        }        
    }
}
