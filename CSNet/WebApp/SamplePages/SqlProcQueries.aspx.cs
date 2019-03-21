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
                        CategoryProductList.DataSource = null;
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
    }
}