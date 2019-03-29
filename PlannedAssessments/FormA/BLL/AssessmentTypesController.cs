﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FormA.Data;
using FormA.DAL;

#endregion

namespace FormA.BLL
{
    public class AssessmentTypesController
    {
        public AssessmentTypes AssessmentTypes_Get(int assessmenttypeid)
        {
            using (var context = new StarTEDContext())
            {
                return context.AssessmentTypes.Find(assessmenttypeid);
            }
        }

        public List<AssessmentTypes> AssessmentType_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.AssessmentTypes.ToList();
            }
        }
    }
}
