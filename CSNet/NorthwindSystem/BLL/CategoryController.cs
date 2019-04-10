using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data; //obtains the <T> devinitions
using NorthwindSystem.DAL;  //obtains the context class
using System.ComponentModel; //exposes classes and methods for use by the ODS IDE developer
#endregion

namespace NorthwindSystem.BLL
{

    //Expose the class for use by the ODS IDE developer. Don't need to do this to use ODS, but you'd have to manually enter parameters.
    [DataObject]
    public class CategoryController
    {
        public Category Category_Get(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }

        //Expose any specific method you wish to the ODS IDE dev
        //The bool here can make it the default method for the IDE dev if set to true. To be safe, set it to false.
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Category> Category_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
