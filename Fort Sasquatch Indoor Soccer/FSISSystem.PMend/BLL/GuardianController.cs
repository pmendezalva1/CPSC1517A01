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
        #region Queries
        public List<Guardian> Guardian_List()
        {
            using (var context = new FSISContext())
            {
                return context.Guardians.ToList();
            }
        }
        public Guardian Guardian_Find(int guardianid)
        {
            //Returns the record from the db where the pKey matches the supplied value.
            using (var context = new FSISContext())
            {
                return context.Guardians.Find(guardianid);
            }
        }
        #endregion
        #region Add, Update and Delete
        public int Guardian_Add(Guardian item)
        {
            using (var context = new FSISContext())
            {
                context.Guardians.Add(item);
                context.SaveChanges();
                return item.GuardianID;
            }
        }
        public int Guardian_Update(Guardian item)
        {
            using (var context = new FSISContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        public int Guardian_Delete(int guardianid)
        {
            using (var context = new FSISContext())
            {
                //Physical delete.
                var existing = context.Guardians.Find(guardianid);
                context.Guardians.Remove(existing);
                return context.SaveChanges();
            }
        }
        #endregion
    }
}
