using Hackaton.Server.Areas.Admin.ViewModels;
using Hackaton.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Server.Areas.Admin.Controllers
{
    public class DashboardController : BaseAdminController
    {
        private ApplicationDbContext _context { get; set; }

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardVM()
            {
                Information = _context.Information.Where(x => !x.IsSeen).Take(20).ToList(),
            };

            foreach (var info in _context.Information)
            {
                info.IsSeen = true;
            }

            await _context.SaveChangesAsync();

            return View("Index", model);
        }
    }
}
