using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Trip.Identity.Areas.Admin.Models;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly ConfigurationDbContext configurationDbContext;

        public DashboardController(SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _signInManager = signInManager;
            this._dbContext = dbContext;
            this.configurationDbContext = configurationDbContext;
        }
        public IActionResult Index()
        {
            var DashboardVM = new GetDashboardVM();
            DashboardVM.Users = _signInManager.UserManager.Users.Count();
            DashboardVM.Roles = _dbContext.Roles.Count();
            DashboardVM.Clients = configurationDbContext.Clients.Count();
            DashboardVM.IdentityResources = configurationDbContext.IdentityResources.Count();
            DashboardVM.ApiResources = configurationDbContext.ApiResources.Count();
            DashboardVM.ApiScopes = configurationDbContext.ApiScopes.Count();
            return View(DashboardVM);
        }
    }
}
