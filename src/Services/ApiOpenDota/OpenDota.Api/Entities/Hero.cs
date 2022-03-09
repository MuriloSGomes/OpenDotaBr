using System.Collections.Generic;

namespace OpenDota.Api.Entities
{
    public class Hero
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localized_name { get; set; }
        public string primary_attr { get; set; }
        public string attack_type { get; set; }
        public List<object> roles { get; set; }
    }
}
