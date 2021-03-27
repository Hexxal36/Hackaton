using Hackaton.Shared.Models;
using System.Collections.Generic;

namespace Hackaton.Server.Areas.Admin.ViewModels
{
    public class InformationIndexVM
    {
        public List<Information> Information { get; set; }

        public int Page { get; set; }
        public int LastPage { get; set; }

        public double minDisox { get; set; }
        public double maxDisox { get; set; }
        public double minOrp { get; set; }
        public double maxOrp { get; set; }
        public double minPh { get; set; }
        public double maxPh { get; set; }
        public double minPressure { get; set; }
        public double maxPressure { get; set; }

        public int deviceId { get; set; }
        public List<Device> Devices { get; set; }
    }
}
