using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Trip.Identity.Areas.Admin.Controllers.Base
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminAreaController : Controller
    {
    }
}
