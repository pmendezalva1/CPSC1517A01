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
        public PlannedAssessment PlannedAssessment_Get(string assessmentid)
        {
            using (var context = new StarTEDContext())
            {
                return context.PlannedAssessments.Find(assessmentid);
            }
        }
        public List<PlannedAssessment> PlannedAssessment_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.PlannedAssessments.ToList();
            }
        }
        public List<PlannedAssessment> PlannedAssessments_FindByCourse(string assessmentid)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<PlannedAssessment> results =
                    context.Database.SqlQuery<PlannedAssessment>("PlannedAssessments_FindByCourse @AssessmentID",
                    new SqlParameter("AssessmentID", assessmentid));
                return results.ToList();
            }
        }

        public void InsertPlannedAssessment(PlannedAssessment insert)
        {
            using (var context = new StarTEDContext())
            {
                PlannedAssessment addAssess = context.PlannedAssessments.Add(insert);
            }
        }
        public void UpdatePlannedAssessment(PlannedAssessment update)
        {
            using (var context = new StarTEDContext())
            {
                PlannedAssessment updateAssess = context.PlannedAssessments.Add(update);
            }
        }

        public void DeletePlannedAssessment(PlannedAssessment delete)
        {
            using (var context = new StarTEDContext())
            {
                PlannedAssessment deleteAssess = context.PlannedAssessments.Remove(delete);
            }
        }
    }
}
