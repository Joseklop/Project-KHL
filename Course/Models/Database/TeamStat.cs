using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Models.Database
{
    public partial class TeamStat
    {
        public int Id { get; set; }
        public string DateName { get; set; } = null!;
        public string TeamName { get; set; } = null!;
        public int? Goals { get; set; }
        public int? Shots { get; set; }
        public int? Face_off_wins { get; set; }
        public int? Penalty_time { get; set; }
        public virtual Game? DateNameNavigation { get; set; }
        public virtual Team? TeamNameNavigation { get; set; }
    }
}
