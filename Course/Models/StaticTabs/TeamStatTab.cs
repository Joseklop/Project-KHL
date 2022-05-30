using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;
using System.Linq;


namespace Course.Models.StaticTabs
{
    public class TeamStatTab : StaticTab
    {
        public TeamStatTab(string h = "", DbSet<TeamStat>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Id");
            DataColumns.Add("DateName");
            DataColumns.Add("TeamName");
            DataColumns.Add("Goals");
            DataColumns.Add("Shots");
            DataColumns.Add("FaceOffWins");
            DataColumns.Add("PenaltyTime");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<TeamStat>? DBS { get; set; }
    }
}
