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
        #region Queries

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

        //to query your database using a non primary key value
        //this will require a sql procedure to call
        //the namespace System.Data.SqlClient is required
        //the returning datatype is IEnumerable<T>
        //this returning datatype will be cast using ToList() on the return
        public List<Product> Products_GetByPartialProductName(string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByPartialProductName @PartialName",
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetBySupplierPartialProductName(int supplierid, string partialproductname)
        {
            using (var context = new NorthwindContext())
            {
                //sometimes there may be a sql error that does not like the new SqlParameter()
                //       coded directly in the SqlQuery call
                //if this happens to you then code your parameters as shown below then
                //       use the parm1 and parm2 in the SqlQuery call instead of the new....
                //don't know why but its weird
                //var parm1 = new SqlParameter("SupplierID", supplierid);
                //var parm2 = new SqlParameter("PartialProductName", partialproductname);
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetBySupplierPartialProductName @SupplierID, @PartialProductName",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("PartialProductName", partialproductname));
                return results.ToList();
            }
        }

        public List<Product> Products_GetForSupplierCategory(int supplierid, int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetForSupplierCategory @SupplierID, @CategoryID",
                                    new SqlParameter("SupplierID", supplierid),
                                    new SqlParameter("CategoryID", categoryid));
                return results.ToList();
            }
        }

        public List<Product> Products_GetByCategoryAndName(int category, string partialname)
        {
            using (var context = new NorthwindContext())
            {
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByCategoryAndName @CategoryID, @PartialName",
                                    new SqlParameter("CategoryID", category),
                                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
        #endregion

        #region Add, Update and Delete

        //The add method will be responsible for adding an instance of Product to the db (via DBSet<T>).
        //Input: Instance of Product class
        //Output: Optional, on a identity pkey, return the new pkey value
        public int Product_Add(Product item)
        {
            //Work will be done in a transaction block
            using (var context = new NorthwindContext())
            {
                //Step 1: Staging
                //The appropriate DBSetwill be used to add the instance <T> to the database.
                //In this step, the data is NOT yet on the database. It's prepped to go to the db. 
                //If your pkey is an identity, then the pkey value will NOT be set. This is very important to remember!
                context.Products.Add(item);

                //Step 2: Commit Add
                //This command, when executed, will send your record to the db for processing and will cause ANY entity validation to fire.
                //If this command is not executed, then your add is rolled back. Same thing happens if the command fails.
                //If this command is executed and your db objects, the add is also rolled back.
                //If no problem exists once it executes, then your add will be committed.
                context.SaveChanges();

                //Optionally, you can return your new pkey value.
                //If your data is committed, then the new pkey value will be in your instance <T> at this time.
                return item.ProductID;
            }
        }

        //The update will receive an instance <T> and will have the pkey value
        //The commit will return the # of rows affected
        public int Product_Update(Product item)
        {
            using (var context = new NorthwindContext())
            {
                //Optional: There could be an attribute(s) on your table that track alterations to the db record 
                //such as Date of Change, Security ID of person making the change 
                //Assume there is an attribute on the record which records the update date.
                //item.LastModified = DateTime.Today;

                //Staging: This update approach will update the entire record on the db that matches the pkey value of the instance
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //Commit: Execution returns the # of rows affected
                return context.SaveChanges();
            }
        }

        //Delete: Will remove the record physically from the db
        //Logical: Will usually set an attribute on the db record indicating that the record should be ignored in normal processing
        //Input: Only the pkey is required
        //Output: # of rows affected
        public int Product_Delete(int productid)
        {
            using (var context = new NorthwindContext())
            {
                ////Physical: Find record on db to delete
                //var existing = context.Products.Find(productid);
                ////Remove the instance (staging)
                //context.Products.Remove(existing);
                ////Commit
                //return context.SaveChanges();

                //Logical: Find record on db to 'delete'
                var existing = context.Products.Find(productid);
                //Staging: The attribute used to flag the records as a logical delete should be set by the controller method
                //and NOT be relied upon by the user.
                existing.Discontinued = true;
                //existing.LastModified = DateTime.Now; as an update

                //The staging for a logical delete is actually an update.
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;

                //commit
                return context.SaveChanges();

            }
        }

        #endregion
    }//end of class (eoc)
}//end of namespace (eon)
