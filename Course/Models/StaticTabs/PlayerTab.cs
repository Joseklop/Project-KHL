using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;
using System.Linq;

namespace Course.Models.StaticTabs
{
    public class PlayerTab : StaticTab
    {
        public PlayerTab(string h = "", DbSet<Player>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("PlayerName");
            DataColumns.Add("TeamName");
            DataColumns.Add("Num");
            DataColumns.Add("Role");
            DataColumns.Add("Age");
            DataColumns.Add("Siticenship");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Player>? DBS { get; set; }
    }
}
