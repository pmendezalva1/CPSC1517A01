using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//The annotations used w/i the .Data project will require the System.ComponentModel.DataAnnotation assembly.
//This assembly is added via your References.

#region AdditionlNamespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthwindSystem.Data
{
    //Use an annotation to link this class to the appropriate SQL table.
    [Table("Products")]
    public class Product
    {
        //mapping of the SQL table attributes will be to class properties.

        private string _QuantityPerUnit;

        /*Use an annotation to identify the primary key.
        1) Identity pkey on your SQL table (default).
            [Key] assumes identity pkey ending in ID or Id
        2) A compound pkey on your SQL table.
            [Key,Column(Order=n)] where n is the numeric value of the physical order of the attribute in the key.
            This basically checks the placement order of the compound key's parts.
        3) A user supplied pkey on your SQL table.
            [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
            If we have to supply the PK, it isn't generated so tell the system that! It'll equal none.
            The default option is the same except None is Identity. This is why we don't need to code it.*/

        [Key] //Remember when it's an identity field like a PK, it doesn't need [Required]. 
        //Anytime the db doesn't create the value and is required, put that key in!
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Product name is required!")]
        [StringLength(40,ErrorMessage ="Product name is limited to 40 characters.")] 
        //First thing to put in is Max, then a Message, Min. Here we're putting in key word parameters.
        public string ProductName { get; set; }
        //Remember that FKs are nullable! They're noted with ? here
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        [StringLength(20, ErrorMessage ="Quantity per unit is limited to 20 characters.")]
        public string QuantityPerUnit //fully implemented to prevent empty strings
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                _QuantityPerUnit = string.IsNullOrEmpty(value) ? null : value; //Don't use .Trim() or it'll break coming back from the db.
            }
        }
        [Range(0.00,double.MaxValue, ErrorMessage ="Unit price must be 0.00 or greater.")]
        public decimal? UnitPrice { get; set; }
        [Range(0, Int16.MaxValue, ErrorMessage ="QoH must be 0 or greater.")]
        public Int16? UnitsInStock { get; set; }
        [Range(0, Int16.MaxValue, ErrorMessage = "QoO must be 0 or greater.")]
        public Int16? UnitsOnOrder { get; set; }
        [Range(0, Int16.MaxValue, ErrorMessage = "ROL must be 0 or greater.")]
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //Sample of a computer field on your SQL. To annotate this property to be taken as a SQL computed field, use:
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public decimal SomeComputedSQLField {get; set;}

        /*Creating a read-only property that is NOT an actual field on your SQL table means that no data is actually transferred.
        Ex. FirstName and LastName attributes are often combined into a single field for display. Assume you need a field like FullName.
        Use the NotMapped annotation to handle this. 
        [NotMapped] 
        public string FullName 
        { get FirstName + " " + LastName; }*/
    }
}
