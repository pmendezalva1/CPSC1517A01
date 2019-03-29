using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FormA.Data;
using FormA.DAL;
using System.Data.SqlClient;
#endregion

namespace FormA.BLL
{
    public class CourseController
    {
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

        public List<Course> Course_GetByPartialName(string partialname)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<Course> results =
                    context.Database.SqlQuery<Course>("Course_GetByPartialName @PartialName",
                    new SqlParameter("PartialName", partialname));
                return results.ToList();
            }
        }
    }
}
