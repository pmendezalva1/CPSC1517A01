using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using A05_System.Data;
using System.Data.Entity;
#endregion

namespace A05_System.DAL
{
    internal class StarTEDContext : DbContext
    {
        public StarTEDContext() : base("StarTEDDb")
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Data.PlannedAssessment> PlannedAssessments { get; set; }
        public DbSet<AssessmentType> AssessmentTypes { get; set; }
    }
}
