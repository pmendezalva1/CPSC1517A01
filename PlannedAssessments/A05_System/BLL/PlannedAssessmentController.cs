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
    public class PlannedAssessmentController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PlannedAssessment PlannedAssessment_Get(int assessmentid)
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


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<PlannedAssessment> PlannedAssessments_FindByCourse(string courseid)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<PlannedAssessment> results =
                    context.Database.SqlQuery<PlannedAssessment>(
                        "PlannedAssessments_FindByCourse @CourseID",
                    new SqlParameter("CourseID", courseid));
                return results.ToList();
            }
        }

        public List<PlannedAssessment> PlannedAssessments_GetByCourseNamePartial(int courseid, string partialcoursename)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<PlannedAssessment> results =
                    context.Database.SqlQuery<PlannedAssessment>("PlannedAssessments_GetByCourseNamePartial @CourseID, @PartialCourseName",
                    new SqlParameter("CourseID", courseid),
                    new SqlParameter("PartialCourseName", partialcoursename));
                return results.ToList();
            }
        }

        /* Insert, Update and Delete */

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int PlannedAssessment_Add(PlannedAssessment item)
        {
            using (var context = new StarTEDContext())
            {
                //Staging: Add an instance of the proper T to the DB.
                context.PlannedAssessments.Add(item);
                //Commit!
                context.SaveChanges();
                //Optional: Return new PKey value
                return item.AssessmentID;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public int PlannedAssessment_Update(PlannedAssessment item)
        {
            using (var context = new StarTEDContext())
            {
                //Updates the entire record on the DB that matches our pkey's instance
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //This is so we know how many rows are affected.
                return context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public int PlannedAssessment_Delete(int assessid)
        {
            using (var context = new StarTEDContext())
            {
                //We're going to logically 'delete' the record here. 
                //To do this, we set Required to true.
                var existing = context.PlannedAssessments.Find(assessid);
                existing.RequiredPass = true;
                //Now, since this is logical, we delete it by updating it!
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                //Now commit!
                return context.SaveChanges();
            }
        }
    }
}

