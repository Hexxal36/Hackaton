using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.Shared.Models
{
    public class Information
    {
        public int Id { get; set; }
        [Required]
        [Range(0, 14)]
        public double PH { get; set; }
        [Required]
        public string DissolvedOxygen { get; set; }
        [Required]
        public double ORP { get; set; }
        [Required]
        public int WaterPressure { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public int DeviceId { get; set; }
    }
}
