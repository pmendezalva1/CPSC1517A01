using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeExercises
{
    public class Information
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public Information()
        {

        }
        public Information(string firstname, string lastname, string username, string emailaddress, string password)
        {
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            EmailAddress = emailaddress;
            Password = password;
        }
    }
    
}