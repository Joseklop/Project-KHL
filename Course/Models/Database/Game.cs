using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Models.Database
{
    public partial class Game
    {
        public string Date { get; set; } = null!;
        public string? Result { get; set; }
        public string? Referee { get; set; }

        public virtual ICollection<PlayerStat>? PlayerStats { get; set; }
        public virtual ICollection<TeamStat>? TeamStats { get; set; }
    }
}
