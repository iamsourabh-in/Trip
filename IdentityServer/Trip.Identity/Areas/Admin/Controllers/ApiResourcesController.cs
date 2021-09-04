using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Trip.Identity.Areas.Admin.Models.ApiResources;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiResourcesController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly IMapper _mapper;


        public ApiResourcesController(IMapper mapper, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _appDbContext = dbContext;
            _configurationDbContext = configurationDbContext;
        }
        // GET: ApiResourcesController
        public ActionResult Index()
        {
            var clients = _mapper.Map<List<ApiResourceListViewModel>>(_configurationDbContext.ApiResources.ToList());

            return View(clients);
        }

        // GET: ApiResourcesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApiResourcesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApiResourcesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ApiResourcesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApiResourcesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ApiResourcesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApiResourcesController/Delete/5
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
