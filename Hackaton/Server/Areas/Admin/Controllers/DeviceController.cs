using Hackaton.Server.Areas.Admin.ViewModels;
using Hackaton.Server.Data;
using Hackaton.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Server.Areas.Admin.Controllers
{
    public class DeviceController : BaseAdminController
    {
        private ApplicationDbContext _context { get; set; }

        public DeviceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1,
            string name = "",
            string location = "",
            string desc = "")
        {
            var allInfo = _context.Information.ToList();

            allInfo.OrderByDescending(x => x.CreatedAt);

            var lastPage = (int)Math.Ceiling((double)allInfo.Count() / 20);


            allInfo = Paginate(allInfo, page);


            var model = new InformationIndexVM()
            {
                Information = allInfo,
                Page = page,
                LastPage = lastPage,
            };
            return View("Index", model);
        }

        private List<Information> Filter(IEnumerable<Information> data,
            int deviceId = 0,
            double minDisox = 0, double maxDisox = 0,
            double minOrp = 0, double maxOrp = 0,
            double minPh = 0, double maxPh = 0,
            double minPressure = 0, double maxPressure = 0)
        {
            if (deviceId != 0)
            {
                data = data.Where(x => x.DeviceId == deviceId);
            }

            if (!(minDisox == 0 && maxDisox == 0))
            {
                data = data.Where(x => x.DissolvedOxygen >= minDisox && x.DissolvedOxygen <= maxDisox);
            }

            if (!(minOrp == 0 && maxOrp == 0))
            {
                data = data.Where(x => x.ORP >= minOrp && x.ORP <= maxOrp);
            }

            if (!(minPh == 0 && maxPh == 0))
            {
                data = data.Where(x => x.PH >= minPh && x.PH <= maxPh);
            }

            if (!(minPressure == 0 && maxPressure == 0))
            {
                data = data.Where(x => x.WaterPressure >= minPressure && x.PH <= maxPressure);
            }

            return data.ToList();
        }

        private List<Information> Sort(IEnumerable<Information> data, string criteria, string direction)
        {
            switch (criteria)
            {
                case "did":
                    data = data.OrderBy(x => x.DeviceId);
                    break;

                case "disox":
                    data = data.OrderBy(x => x.DissolvedOxygen);
                    break;

                case "orp":
                    data = data.OrderBy(x => x.ORP);
                    break;

                case "ph":
                    data = data.OrderBy(x => x.PH);
                    break;

                case "press":
                    data = data.OrderBy(x => x.WaterPressure);
                    break;

                case "":
                    break;
            }

            if (direction == "desc")
            {
                data = data.Reverse();
            }

            return data.ToList();
        }

        private List<Information> Paginate(IEnumerable<Information> data, int page)
        {
            return data.Skip((page - 1) * 20).Take(20).ToList();
        }

    }
}
