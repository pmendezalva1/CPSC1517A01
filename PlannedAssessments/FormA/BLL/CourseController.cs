﻿using System;
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
        //public int AddCourse(Course item)
        //{
        //    using (var context = new StarTEDContext())
        //    {
        //        Course addCourse = context.Courses.Add(item);
        //    }
        //}
        //public void UpdateCourse(Course item)
        //{
        //    using (var context = new StarTEDContext())
        //    {
                
        //    }
        //}


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
        //public List<Course> Courses_GetByPartialAssessName(int assessmentid, string partialname)
        //{
        //    using (var context = new StarTEDContext())
        //    {
        //        IEnumerable<Course> results =
        //                context.Database.SqlQuery<Course>("Courses_GetByPartialAssessName @AssessmentID, @PartialName",
        //                                new SqlParameter("AssessmentID", assessmentid),
        //                                new SqlParameter("PartialName", partialname));
        //        return results.ToList();
        //    }
        //}
    }
}
