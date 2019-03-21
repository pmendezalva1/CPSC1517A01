using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Data;

#endregion

namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Clear out old messages.
            MessageLabel.Text = "";

            //Load the dropdownlist (ddl) control with a sorted list of categories.
            //This load will be done once when the page first is processed.
            if(!Page.IsPostBack)
            {
                //Need to use user friendly error handling.
                try
                {
                    //The data collection will come from the db.
                    //Create and connect to the appropriate BLL class.
                    CategoryController sysmgr = new CategoryController();
                    //Issue a request for data via the appropriate BLL class method.
                    List<Category> datainfo = sysmgr.Category_List();
                    //Optionally: Sort the collection
                    datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName)); //Ascending; swap x and y for desc.
                    //Attach the data to the DDL control
                    CategoryList.DataSource = datainfo;
                    //Indicate the data properties for DataTextField and DataValueField
                    CategoryList.DataTextField = nameof(Category.CategoryName);
                    CategoryList.DataValueField = nameof(Category.CategoryID);
                    //Physically bind the data to the DDL.
                    CategoryList.DataBind();
                    //Optionally: Place a prompt on the DDL.
                    CategoryList.Items.Insert(0, "select...");

                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }


            }


        }

       
    }
}