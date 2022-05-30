using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Course.Models.Database;

namespace Course.Models.StaticTabs
{
    public class GameTab : StaticTab
    {
        public GameTab(string h = "", DbSet<Game>? dBS = null) : base(h)
        {
            DBS = dBS;
            DataColumns = new List<string>();
            DataColumns.Add("Date");
            DataColumns.Add("Result");
            DataColumns.Add("Referee");
            ObjectList = DBS.ToList<object>();
        }

        new public DbSet<Game>? DBS { get; set; }
    }
}
