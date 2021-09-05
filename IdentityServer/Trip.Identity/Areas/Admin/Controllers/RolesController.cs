using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Identity.Areas.Admin.Models.Roles;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly IMapper _mapper;


        public RolesController(IMapper mapper, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _appDbContext = dbContext;
            _configurationDbContext = configurationDbContext;
        }

        // GET: RolesController
        public async Task<ActionResult> Index()
        {
            var roles = _mapper.Map<List<RoleListViewModel>>(_roleManager.Roles.ToList());
            return View(roles);
        }

        // GET: RolesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var roles = _mapper.Map<List<RoleListViewModel>>(await _roleManager.FindByIdAsync(id));
            return View(roles);
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var roleName = collection["Name"].ToString();
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role is not null)
                    throw new Exception("Role already Exists");
                await _roleManager.CreateAsync(new IdentityRole() { Name = roleName, NormalizedName = roleName.ToLower() });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var roles = _mapper.Map<List<RoleListViewModel>>(await _roleManager.FindByIdAsync(id));
            return View(roles);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, IFormCollection collection)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);

                var roleName = collection["Name"].ToString();
                var xrole = _roleManager.FindByNameAsync(roleName);
                if (xrole is not null)
                    throw new Exception("Role already Exists");

                role.Name = roleName;
                await _roleManager.UpdateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
