using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        public static List<GridViewData> gvCollection;//We only use this when we aren't using DBs!
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                gvCollection = new List<GridViewData>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Assume all data is valid.
            //The class level List<T> will hold the collection of data for the page (we have no db).
            //The data collection will be displayed in a table-like grid control (tabular): GridView.

            string fullname = FullName.Text;
            string emailaddress = EmailAddress.Text;
            string phonenumber = PhoneNumber.Text;
            string fullorparttime = FullOrPartTime.Text;

            //The checkbox list can have several options selected. Each option needs to be recorded.
            //Traverse the options of the control, record each selected option.
            //CheckBoxList option are a collection of rows. 
            //foreach will loop thru a collection of rows.

            string jobs = "";
            foreach(ListItem jobrow in Jobs.Items)
            {
                if(jobrow.Selected)
                {
                    jobs += jobrow.Text + " ";
                }
            }

            gvCollection.Add(new GridViewData(fullname, emailaddress, phonenumber, fullorparttime, jobs));

            //Display the data collection to an appropriate control that will display multiple columns
            //A dropdown list won't have enough rows, so we need to use a WebGrid called a GridView.
            JobApplicantList.DataSource = gvCollection;
            JobApplicantList.DataBind();
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            FullOrPartTime.SelectedIndex = -1; //Invalid so it prevents anything from turning on. Or use:
            //FullOrPartTime.ClearSelection();
            //Jobs.SelectedIndex = -1;
            Jobs.ClearSelection();
            JobApplicantList.DataSource = null;
            JobApplicantList.DataBind();
        }
    }
}