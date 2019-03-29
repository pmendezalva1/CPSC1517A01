using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormA.Data
{
    public class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public double Credits { get; set; }
        public int TotalHours { get; set; }
        public string ClassroomTypes { get; set; }
        public int Terms { get; set; }
        public double Tuition { get; set; }
        public string Description { get; set; }
    }
}
