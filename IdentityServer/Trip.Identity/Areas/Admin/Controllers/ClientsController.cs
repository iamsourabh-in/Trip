using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Trip.Identity.Areas.Admin.Models;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdministratorRole")]
    public class ClientsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly ConfigurationDbContext configurationDbContext;

        public ClientsController(IMapper mapper, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            this._dbContext = dbContext;
            this.configurationDbContext = configurationDbContext;
        }

        // GET: ClientsController
        public ActionResult Index()
        {
            var clients = _mapper.Map<List<ClientViewModel>>(configurationDbContext.Clients.ToList());

            return View(clients);
        }

        // GET: ClientsController/Details/5
        public ActionResult Details(int id)
        {
            var client = _mapper.Map<ClientViewModel>(configurationDbContext.Clients.FirstOrDefault(c => c.Id == id));
            return View(client);
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientsController/Create
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

        // GET: ClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _mapper.Map<ClientViewModel>(configurationDbContext.Clients.FirstOrDefault(c => c.Id == id));
            return View(client);
        }

        // POST: ClientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var client = configurationDbContext.Clients.FirstOrDefault(c => c.Id == id);
                client.ClientId = collection["ClientId"];
                configurationDbContext.Clients.Update(client);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientsController/Delete/5
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
