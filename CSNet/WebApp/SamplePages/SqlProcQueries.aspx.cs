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

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Ensure a selection was made.
            if (CategoryList.SelectedIndex == 0) //points to physical position in our list
            {
                //No selection: Message to the user
                MessageLabel.Text = "Select a category to view category products.";
            }
            else
            {
                //Selection: Process request for lookup
                //User friendly error handling
                try
                {
                    //Create and connect to the appropriate BLL class
                    ProductController sysmgr = new ProductController();
                    //Issue the lookup request using the appropriate BLL class method and capture results.
                    List<Product> results = sysmgr.Product_GetByCategories(int.Parse(CategoryList.SelectedValue));
                    //Test the results (.Count() == 0 since it's multiple)
                    if (results.Count() == 0)
                    {
                        //No results: Bad, not found message.
                        MessageLabel.Text = "No products found for requested category.";
                        //Optional: Clear the previous successful data display.
                        //CategoryProductList.DataSource = null;

                        //If you have an EmptyDataTemplate, you can assign the empty dataset results to the GridView,
                        //the empty dataset will trigger the display of the template.
                        CategoryProductList.DataSource = results;
                        CategoryProductList.DataBind();
                    }
                    else
                    {
                        //Results: Display returned data.
                        CategoryProductList.DataSource = results;
                        CategoryProductList.DataBind();
                        //These load the gridview.
                    }

                }

                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }          
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }

        protected void CategoryProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //The gridview uses the PageIndex to calculate which rows out of your dataset to display; all other rows are ignored.
            //When switching pages, you MUST set the PageIndex property. 
            //Data for the new page index will come from the "e" parameter of this method. ^
            CategoryProductList.PageIndex = e.NewPageIndex;

            //The second step in this method is to refresh the dataset of the control. 
            //This can be done by reassigning the dataset to the control. 
            //Since our data collection is coming from the db, depending on the selected category, we need to issue another call to the db.
            //Then we bind that data to the control.
            Submit_Click(sender, new EventArgs()); //Pass in an instance of the class here. Don't let ASP.NET webforms get in the way of knowing C#!
        }

        protected void CategoryProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Accessing data on a GridView cell is dependant on the web control datatype.
            //Syntax for accessing your control: (gvcontrolpointer.FindControl("cellcontrolid") as cellcontroltype).controlaccesstype;
            //gvcontrolpointer - Reference to the gridview row we're interested in.
            //cellcontrolid - ID of the control in the cell.
            //cellcontroltype - Type of web control in the cell (in our case, most are labels).
            //controlaccesstype - How is the web control accessed (for a label, it's .Text)

            //Personal style.
            GridViewRow agvrow = CategoryProductList.Rows[CategoryProductList.SelectedIndex];
            string productid = (agvrow.FindControl("ProductID") as Label).Text;
            string productname = (agvrow.FindControl("ProductName") as Label).Text;
            string discontinued = "";
            if ((agvrow.FindControl("Discontinued") as CheckBox).Checked)
            {
                discontinued = "discontinued";
            }
            else
            {
                discontinued = "available";
            }
            MessageLabel.Text = productname + " (" + productid + ") is " + discontinued;
        }
    }
}