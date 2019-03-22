using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_PMendezAlva
{
    public partial class BookForm : System.Web.UI.Page
    {
        public static List<Books> bookInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                bookInfo = new List<Books>();
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string isbn = ISBN.Text;
            string name = Name.Text;
            double cost = double.Parse(PurchaseCost.Text);
            double price = double.Parse(SellingPrice.Text);

            //if(bookInfo.Contains(isbn))
            //{
            //    Message.Text = "This book is already registered! Please pick a different ISBN.";
            //}
            
            //else
            //{
                bookInfo.Add(new Books(isbn, name, cost, price));
                Message.Text = "Your book has been registered!";
            //}
            BookListDisplay.DataSource = bookInfo;
            BookListDisplay.DataBind();
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            ISBN.Text = "";
            Name.Text = "";
            PurchaseCost.Text = "";
            SellingPrice.Text = "";
            Message.Text = "Cleared!";

            BookListDisplay.DataSource = null;
            BookListDisplay.DataBind();
        }
    }
}