using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;
using System.Linq;

namespace Course.Models.StaticTabs
{
    public class TeamTab : StaticTab
    {
        public TeamTab(string h = "", DbSet<Team>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Name");
            DataColumns.Add("City");
            DataColumns.Add("Stadium");
            DataColumns.Add("Coach");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Team>? DBS { get; set; }
    }
}
