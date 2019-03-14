using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        //The only reason why we are using this List<T> is b/c we do not have a db to store our data!
        //We are also not using ViewState, cookies or session variables.

        public static List<Entries> entryCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                //First time page is processed
                entryCollection = new List<Entries>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //Validate the incoming data. Validate that the terms were accepted, they are not part of our data object!
                if (Terms.Checked)
                {
                    //Yes: Create and load entry. We need to add to storage; display entries.
                    string firstname = FirstName.Text;
                    string lastname = LastName.Text;
                    string streetaddressone = StreetAddress1.Text;
                    string streetaddresstwo = StreetAddress2.Text;
                    string city = City.Text;
                    string province = Province.Text;
                    string postalcode = PostalCode.Text;
                    string email = EmailAddress.Text;
                    string terms = Terms.Text;
                    string answer = CheckAnswer.Text;

                    Message.Text = "Entry accepted!";

                }
                else
                {
                    //No: rejection message.
                    Message.Text = "You did not accept the terms of the contest. Entry rejected.";
                }
                
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";
            CheckAnswer.Text = "";
            Province.SelectedIndex = 0;
            Terms.Checked = false;
        }
    }
}