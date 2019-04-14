using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FSISSystem.PMend.Data; //Obtains <T> Defs
using FSISSystem.PMend.DAL; //Obtains context class
using System.Data.Entity;
#endregion

namespace FSISSystem.PMend.BLL
{
    public class GuardianController
    {
        public List<Guardian> Guardian_List()
        {
            using (var context = new FSISContext())
            {
                return context.Guardians.ToList();
            }
        }
        public Guardian Guardian_Find(int guardianid)
        {
            using (var context = new FSISContext())
            {
                return context.Guardians.Find(guardianid);
            }
        }
    }
}
