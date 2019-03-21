using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data; //the .data class
using NorthwindSystem.DAL; //the DAL context class
#endregion

namespace NorthwindSystem.BLL
{
    //The classes within the BLL are referred to as your interface. These classes will be xalled by your webapp. They're public.
    //For ease of maintenance, each class will represent a specific data class, ie. Product.

    public class ProductController
    {
        //Create a method to find a specific record on the SQL table. This will be done by the primary key.
        //Input: search arg value, output: results of the search > single Product record for this case.
        //This method is public.
        public Product Product_Get(int productid)
        {
            //Connect to the appropriate context class to access the db.
            //Create an instance of the appropriate context class.
            //Accessing the appropriate DBSet<T>, issue a request for execution against the SQL table.
            //The appropriate request return data will be received. 
            //Return these results. 
            //The request will be done in a transaction. For read-only, we don't need to worry.
            //This lookup is by PRIMARY KEY.
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }

        //Obtain a list of all table records.
        //Input: None
        //Output: List<T> where <T> is the appropriate data class (Product)

        public List<Product> Product_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList(); //Extensions of the DBSet class. Built in.
            }
        }
    }
}
