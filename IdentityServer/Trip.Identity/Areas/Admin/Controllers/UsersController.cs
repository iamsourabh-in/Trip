using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Trip.Identity.Areas.Admin.Controllers.Base;
using Trip.Identity.Areas.Admin.Models;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : AdminAreaController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly IMapper _mapper;


        public UsersController(IMapper mapper, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _appDbContext = dbContext;
            _configurationDbContext = configurationDbContext;
        }

        // GET: UsersController
        public ActionResult Index()
        {

            var users = _mapper.Map<List<UserViewModel>>(_signInManager.UserManager.Users);
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(string id)
        {
            var user = _mapper.Map<UserViewModel>(_signInManager.UserManager.Users.FirstOrDefault(u => u.Id == id));
            return View(user);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
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

        // GET: UsersController/Edit/5
        public ActionResult Edit(string id)
        {
            var user = _mapper.Map<UserViewModel>(_signInManager.UserManager.Users.FirstOrDefault(u => u.Id == id));
            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var user = _signInManager.UserManager.Users.FirstOrDefault(u => u.Id == id);
                user.FirstName = collection["FirstName"];
                user.LastName = collection["LastName"];
                user.Email = collection["Email"];
                user.PhoneNumber = collection["PhoneNumber"];
                _signInManager.UserManager.UpdateAsync(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
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
