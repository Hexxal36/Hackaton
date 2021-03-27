using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.Shared.Models
{
    public class Device
    {
        public Device()
        {
            Info = new List<Information>();
        }

        public int Id { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longtitude { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Information> Info { get; set; }
    }
}
