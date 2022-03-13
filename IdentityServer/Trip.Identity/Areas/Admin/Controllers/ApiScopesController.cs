using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Trip.Identity.Areas.Admin.Controllers.Base;
using Trip.Identity.Areas.Admin.Models.ApiScopes;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{

    public class ApiScopesController : AdminAreaController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly IMapper _mapper;


        public ApiScopesController(IMapper mapper, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _appDbContext = dbContext;
            _configurationDbContext = configurationDbContext;
        }



        // GET: ApiScopesController
        public ActionResult Index()
        {
            var scopes = _mapper.Map<List<ApiScopeListViewModel>>(_configurationDbContext.ApiScopes.ToList());
            return View(scopes);
        }

        // GET: ApiScopesController/Details/5
        public ActionResult Details(int id)
        {
            var scope = _mapper.Map<ApiScopeListViewModel>(_configurationDbContext.ApiScopes.FirstOrDefault(api => api.Id == id));
            return View(scope);
            
        }

        // GET: ApiScopesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApiScopesController/Create
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

        // GET: ApiScopesController/Edit/5
        public ActionResult Edit(int id)
        {
            var scope = _mapper.Map<ApiScopeListViewModel>(_configurationDbContext.ApiScopes.FirstOrDefault(api => api.Id == id));
            return View(scope);
        }

        // POST: ApiScopesController/Edit/5
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

        // GET: ApiScopesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApiScopesController/Delete/5
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
