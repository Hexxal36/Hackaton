using Hackaton.Server;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton.Server.Areas.Admin.Controllers
{
    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    [Area("Admin")]
    public class BaseAdminController : Controller
    {
    }
}
