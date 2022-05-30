using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Models.Database
{
    public partial class PlayerStat
    {
        public int Id { get; set; }
        public string DateName { get; set; } = null!;
        public string PlayerName { get; set; } = null!;
        public int? Player_goals { get; set; }
        public int? Passes { get; set; }
        public int? Score { get; set; }
        public int? Player_shots { get; set; }
        public int? Player_penalty_time { get; set; }


        public virtual Game DateNameNavigation { get; set; } = null!;
        public virtual Player PlayerNameNavigation { get; set; } = null!;
    }
}
