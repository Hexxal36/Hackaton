using Hackaton.Server.Areas.Admin.ViewModels;
using Hackaton.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton.Server.Areas.Admin.Controllers
{
    public class InformationController : BaseAdminController
    {
        private ApplicationDbContext _context { get; set; }

        public InformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new InformationIndexVM()
            {
                Information = _context.Information.ToList(),
            };

            return View("Index", model);
        }
    }
}
