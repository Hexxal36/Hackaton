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
        [Range(0, 6)]
        [Required]
        public int WaterQuality { get; set; }
        [Required]
        public int WaterPressure { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public int DeviceId { get; set; }
    }
}
