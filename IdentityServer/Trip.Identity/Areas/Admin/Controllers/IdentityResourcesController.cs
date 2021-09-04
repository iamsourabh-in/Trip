using AutoMapper;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Trip.Identity.Areas.Admin.Models.IdentityResource;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IdentityResourcesController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly IMapper _mapper;


        public IdentityResourcesController(IMapper mapper, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _appDbContext = dbContext;
            _configurationDbContext = configurationDbContext;
        }
        public IActionResult Index()
        {
            var clients = _mapper.Map<List<IdentityResourceListViewModel>>(_configurationDbContext.IdentityResources.ToList());

            return View(clients);
        }
    }
}
