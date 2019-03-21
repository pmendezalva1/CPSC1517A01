using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL; //Controller class
using NorthwindSystem.Data; //Data definition class

#endregion

namespace WebApp.SamplePages
{
    public partial class SimpleQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Clear out old messages.
            MessageLabel.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int productid = 0;

            //Validation
            if (string.IsNullOrEmpty(SearchArg.Text.Trim()))
            {
                MessageLabel.Text = "Enter a product ID to search.";
            }
            else if (int.TryParse(SearchArg.Text.Trim(), out productid))
            {
                //Good: Process database request
                try
                {
                    //Connect to BLL controller
                    ProductController sysmgr = new ProductController();
                    //Issue request to controller
                    Product results = sysmgr.Product_Get(int.Parse(SearchArg.Text.Trim())); //Or just use productid instead of the parse
                    //Check results: Single record check == null
                    if (results == null)
                    {
                        //If None: message to user
                        MessageLabel.Text = "No data found for supplied search value.";
                    }
                    else
                    {
                        //Found: Display data
                        ProductID.Text = results.ProductID.ToString();
                        ProductName.Text = results.ProductName;
                    }

                }
                catch (Exception ex)
                {
                    //Bad: Message to user
                    MessageLabel.Text = ex.Message;
                }
            }
            else
            {
                //Bad: Message to user
                MessageLabel.Text = "Product ID is not a number greater than 0.";
            }

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            SearchArg.Text = "";
            ProductID.Text = "";
            ProductName.Text = "";
        }
    }
}