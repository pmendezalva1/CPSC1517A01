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
    public class PlannedAssessmentController
    {
        public PlannedAssessments PlannedAssessment_Get(int assessmentid)
        {
            using (var context = new StarTEDContext())
            {
                return context.PlannedAssessments.Find(assessmentid);
            }
        }
        public List<PlannedAssessments> PlannedAssessment_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.PlannedAssessments.ToList();
            }
        }
        public List<PlannedAssessments> PlannedAssessment_FindByCourse(int assessmentid, string coursename)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<PlannedAssessments> results =
                    context.Database.SqlQuery<PlannedAssessments>("PlannedAssessment_FindByCourse @AssessmentID, @CourseName",
                    new SqlParameter("AssessmentID", assessmentid),                
                    new SqlParameter("CourseName", coursename));
                return results.ToList();
            }
        }
    }
}
