using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class Entries
    {
        public string _StreetAddress2;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddresss2
        {
            get
            {
                return _StreetAddress2;
            }
            set
            {
                _StreetAddress2 = string.IsNullOrEmpty(value.Trim()) ? null : value;
            }
        }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }

        public Entries()
        {

        }
        public Entries(string firstname, string lastname, string streetaddress1, string streetaddress2, string city,
            string province, string postalcode, string emailaddress)
        {
            FirstName = firstname;
            LastName = lastname;
            StreetAddress1 = streetaddress1;
            StreetAddresss2 = streetaddress2;
            City = city;
            Province = province;
            PostalCode = postalcode;
            EmailAddress = emailaddress;
        }
    }
}