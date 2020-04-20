using System.ComponentModel.DataAnnotations;

namespace APIDIS2.Models
{
    public class Fireball_model
    {
        public class description_fireball
        {
            [Key]
            public string date { get; set; }
            public string energy { get; set; }
            public string impact_e { get; set; }
            public string latitude { get; set; }
            public string lat_dir { get; set; }
            public string longitude { get; set; }
            public string long_dir { get; set; }
            public int altitude { get; set; }
            public int velocity { get; set; }
        }
    }
}
