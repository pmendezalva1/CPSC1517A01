using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeExercises.Exercises
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        public static List<Information> infoCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                //1st time processing
                infoCollection = new List<Information>();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Validate incoming data and terms were accepted!
                if (Terms.Checked)
                {
                    //Yes: Create & load entry, add to storage.
                    string firstname = FirstName.Text;
                    string lastname = LastName.Text;
                    string username = Username.Text;
                    string emailaddress = EmailAddress.Text;
                    string password = Password.Text;

                    Message.Text = "Thank you for registering with us!";
                }
                else
                {
                    //Nope
                    Message.Text = "Please don't forget to accept the terms of the site!";
                }
            }
        }
    }
}