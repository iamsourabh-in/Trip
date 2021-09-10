using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Identity.Areas.Admin.Models.UserRoles;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRolesController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(IMapper mapper, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _mapper = mapper;
            this._roleManager = roleManager;
            _signInManager = signInManager;
            _appDbContext = dbContext;
            _configurationDbContext = configurationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string userId)
        {
            ViewBag.UserId = userId;
            var user = await _signInManager.UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User not found";
                return View("NotFound");
            }

            var model = new List<UserRolesViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var roleModel = new UserRolesViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _signInManager.UserManager.IsInRoleAsync(user, role.Name))
                {
                    roleModel.IsSelected = true;
                }
                model.Add(roleModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<UserRolesViewModel> userRolesModel, string userId)
        {

            var user = await _signInManager.UserManager.FindByIdAsync(userId);
            if (user is null)
            {
                ViewBag.ErrorMessage = $"User not found";
                return View("NotFound");
            }

            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            var result = await _signInManager.UserManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", $"Cannot Remove Existing Roles");
                return View(userRolesModel);
            }
            userRolesModel = new List<UserRolesViewModel>() { new UserRolesViewModel { RoleName = "Admin" } };

            await _signInManager.UserManager.AddToRolesAsync(user, userRolesModel.Where(r => r.IsSelected).Select(r => r.RoleName).ToList());

            return RedirectToAction("Edit", "Users", new { Id = userId });
        }
    }
}
