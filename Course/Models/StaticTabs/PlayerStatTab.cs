using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;

namespace Course.Models.StaticTabs
{
    public class PlayerStatTab : StaticTab
    {
        public PlayerStatTab(string h = "", DbSet<PlayerStat>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Id");
            DataColumns.Add("DateName");
            DataColumns.Add("PlayerName");
            DataColumns.Add("PlayerGoals");
            DataColumns.Add("Passes");
            DataColumns.Add("Score");
            DataColumns.Add("PlayerShots");
            DataColumns.Add("PlayerPenaltyTime");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<PlayerStat>? DBS { get; set; }
    }
}
