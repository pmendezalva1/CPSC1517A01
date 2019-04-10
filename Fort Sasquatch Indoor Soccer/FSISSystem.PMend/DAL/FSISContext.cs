using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using FSISSystem.PMend.Data; //Allows access to <T> Definitions
using System.Data.Entity; //Access to EntityFramework
#endregion

namespace FSISSystem.PMend.DAL
{
    internal class FSISContext : DbContext
    {
        public FSISContext() : base("FSIS_db")
        {

        }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
