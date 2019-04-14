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
    [Table("Player")]
    public class Player
    {

        private string _MedicalAlertDetails;
        private string _Gender;

        [Key, Column(Order =1)]
        public int PlayerID { get; set; }
        [Key, Column(Order =2)]
        public int GuardianID { get; set; }
        [Key, Column(Order =3)]
        public int TeamID { get; set; }
        [Required(ErrorMessage ="First name is required.")]
        [StringLength(50, ErrorMessage ="First name is limited to 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name is limited to 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Age is required.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(1, ErrorMessage = "Please enter M or F!")]
        public string Gender //Use this one for the textbox/processing!
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value.ToUpper();
            }
        }
        [Required(ErrorMessage ="Alberta Health Care number is required.")]
        [StringLength(10, ErrorMessage = "Alberta Health Care Number is limited to 10 characters.")]
        public string AlbertaHealthCareNumber { get; set; }
        [StringLength(250, ErrorMessage = "Medical alert details are limited to 250 characters.")]
        public string MedicalAlertDetails
        {
            get
            {
                return _MedicalAlertDetails;
            }
            set
            {
                _MedicalAlertDetails = string.IsNullOrEmpty(value) ? null : value;
            }
        }

        [NotMapped]
        public string FullName
        {
            get { return LastName + " " + FirstName; }
            
        }

        [NotMapped]
        public string GenderName //Use this to display!
        {
            get { return _Gender == "M" ? "Male" : "Female"; }
        }
    }
}
