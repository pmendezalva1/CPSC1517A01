using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel;
using A05_System.Data;
using A05_System.DAL;
using System.Data.SqlClient;

#endregion

namespace A05_System.BLL
{
    [DataObject]
    public class CourseController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Course Course_Get(int courseid)
        {
            using (var context = new StarTEDContext())
            {
                return context.Courses.Find(courseid);
            }
        }
        public List<Course> Course_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.Courses.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Course> Courses_FindByPartialName(string partialname)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<Course> results =
                    context.Database.SqlQuery<Course>("Courses_FindByPartialName @PartialName",
                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
    }
}
