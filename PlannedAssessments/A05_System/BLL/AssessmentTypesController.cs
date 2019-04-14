using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel;
using A05_System.Data;
using A05_System.DAL;

#endregion

namespace A05_System.BLL
{
    [DataObject]
    public class AssessmentTypesController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AssessmentType AssessmentTypes_Get(int assessmenttypeid)
        {
            using (var context = new StarTEDContext())
            {
                return context.AssessmentTypes.Find(assessmenttypeid);
            }
        }

        public List<AssessmentType> AssessmentType_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.AssessmentTypes.ToList();
            }
        }
    }
}
