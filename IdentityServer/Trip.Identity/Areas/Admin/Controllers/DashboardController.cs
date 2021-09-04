using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Identity.Areas.Admin.Models;
using Trip.Identity.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext dbContext;
        private readonly ConfigurationDbContext configurationDbContext;

        public DashboardController(SignInManager<IdentityUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _signInManager = signInManager;
            this.dbContext = dbContext;
            this.configurationDbContext = configurationDbContext;
        }
        public IActionResult Index()
        {
            var DashboardVM = new GetDashboardVM();
            DashboardVM.Users = _signInManager.UserManager.Users.Count();
            DashboardVM.Roles = dbContext.Roles.Count();
            DashboardVM.Clients = configurationDbContext.Clients.Count();
            DashboardVM.Resources = configurationDbContext.ApiResources.Count();
            return View(DashboardVM);
        }
    }
}
