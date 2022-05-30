using System;
using System.Collections.Generic;

namespace Course.Models.Database
{
    public partial class Player
    {
        public string PlayerName { get; set; } = null!;
        public string? TeamName { get; set; }
        public int? Num { get; set; }
        public string? Role { get; set; }
        public int? Age { get; set; }
        public string? Siticenship { get; set; }

        public virtual ICollection<PlayerStat> PlayerStats { get; set; } = null!;

        public virtual Team? TeamNameNavigation { get; set; }
    }
}
