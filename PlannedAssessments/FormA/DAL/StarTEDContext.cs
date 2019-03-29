using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FormA.Data;
using System.Data.Entity;
#endregion

namespace FormA.DAL
{
    internal class StarTEDContext:DbContext
    {
        public StarTEDContext():base("StarTED")
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<PlannedAssessments> PlannedAssessments { get; set; }
        public DbSet<AssessmentTypes> AssessmentTypes { get; set; }
    }
}
