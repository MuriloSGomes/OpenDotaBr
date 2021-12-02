using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDota.Api.Entities
{
    public class PlayerRank
    {
        public int account_id { get; set; }
        public int rating { get; set; }
        public bool? fh_unavailable { get; set; }
    }
}
