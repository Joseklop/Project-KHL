using System;
using System.Collections.Generic;

namespace Course.Models.Database
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            TeamStats = new HashSet<TeamStat>();
        }
        public string Name { get; set; } = null!;
        public string? City { get; set; }
        public string? Stadium { get; set; }
        public string? Coach { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<TeamStat> TeamStats { get; set; }
    }
}
