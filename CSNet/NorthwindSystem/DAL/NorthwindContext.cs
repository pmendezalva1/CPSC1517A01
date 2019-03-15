using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region AdditionalNamespaces
using NorthwindSystem.Data; //Allows access to <T> definitions.
using System.Data.Entity; //Allows access to EntityFramework ADO.Net stuff.
#endregion

/*This class needs to have access to ADO.Net in EntityFramework.
The nuGet package EntityFramework has already been added to this project. 
This project also needs the assembly System.Data.Entity. 
This project will need Using clauses that point to:
a) System.Data.Entity namespace
b) Your data project namespace*/

namespace NorthwindSystem.DAL
{
    //The class access is restricted to requests from within the library by using internal.
    //The class inherits (ties into EntityFramework) the class DbContext.
    internal class NorthwindContext:DbContext
    {
        //Setup class default constructor to supply your connection string name to the DbContext inherited class.
        public NorthwindContext():base("NWDB")
        {

        }

        //Create an EntityFramework DbSet<T> for each mapped SQL table. <T> is your class in the .Data project.
        //This is a property.
        public DbSet<Product> Products { get; set; }

    }
}
