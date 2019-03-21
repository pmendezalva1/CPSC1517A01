using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data; //the .data class
using NorthwindSystem.DAL; //the DAL context class
using System.Data.SqlClient; //Required for SQL parameter
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

        //This db query is NOT based on the primary key.
        //.Find is based on the primary key, therefore it cannot be used.
        //Instead, we will use a Database.SQLQuery<T> method.
        //T reps w/e table we're talking about. This method will have 1 or more arguments. 
        //a) The SQL execution request for a procedure
        //b) Optional. Any parameter(s) needed by (a).
        //Arguments are specified using New SqlParameter (parameter, value).
        //Each required argument needs a SQLParameter();
        //SQL Parameter needs a using clause System.Data.SQLClient
        
        public List<Product> Product_GetByCategories(int categoryid)
        {
            //Non primary queries
            using (var context = new NorthwindContext())
            {
                //Most data sets are returned from DBSet as an IEnumerable<T> data type.
                //We convert this datatype to a List<T> using .ToList();
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>(
                        "Products_GetByCategories @CategoryID", //a
                        new SqlParameter("CategoryID", categoryid)); //We don't put on the @ sign for this, but we do for the first portion.
                return results.ToList();
            }
        }
    }
}
