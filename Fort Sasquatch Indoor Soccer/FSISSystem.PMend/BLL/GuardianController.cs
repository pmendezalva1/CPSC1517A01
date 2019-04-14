using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FSISSystem.PMend.Data; //Obtains <T> Defs
using FSISSystem.PMend.DAL; //Obtains context class
using System.Data.Entity;
using System.Data.SqlClient;
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
                IEnumerable<Guardian> results =
                    context.Database.SqlQuery<Guardian>(
                        "Guardian_Find @GuardianID",
                        new SqlParameter("GuardianID", guardianid));
                return results.ToList();
            }
        }
    }
}
