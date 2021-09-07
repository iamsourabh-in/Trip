using AutoMapper;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trip.Identity.Areas.Admin.Models.Accounts;
using Trip.Identity.Persistence.Data;

namespace Trip.Identity.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _appDbContext;
        private readonly ConfigurationDbContext _configurationDbContext;
        private readonly IMapper _mapper;
        private readonly RoleManager<ApplicationUser> _roleManager;

        public AccountController(IMapper mapper, RoleManager<ApplicationUser> roleManager SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext, ConfigurationDbContext configurationDbContext)
        {
            _mapper = mapper;
            this._roleManager = roleManager;
            _signInManager = signInManager;
            _appDbContext = dbContext;
            _configurationDbContext = configurationDbContext;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new AdminLoginViewModel
            {

                ReturnUrl = returnUrl,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // find user by username
                var user = await _signInManager.UserManager.FindByNameAsync(model.Username);

                // validate username/password against in-memory store
                if (user != null && (await _signInManager.CheckPasswordSignInAsync(user, model.Password, true)) == Microsoft.AspNetCore.Identity.SignInResult.Success)
                {
                    var roles = _roleManager.GetClaimsAsync(user);
                    // await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: context?.Client.ClientId));

                    // only set explicit expiration here if user chooses "remember me". 
                    // otherwise we rely upon expiration configured in cookie middleware.
                    AuthenticationProperties props = null;
                    if (model.RememberLogin)
                    {
                        props = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.Add(new TimeSpan(3000))
                        };
                    };

                    // issue authentication cookie with subject ID and username
                    var isuser = new IdentityServerUser(user.Id)
                    {
                        DisplayName = user.UserName
                    };

                    await HttpContext.SignInAsync(isuser, props);


                    // request for a local page
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                    else
                    {
                        // user might have clicked on a malicious link - should be logged
                        throw new Exception("invalid return URL");
                    }
                }

                // await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials", clientId: context?.Client.ClientId));
                ModelState.AddModelError(string.Empty, "Invalid Credential");

            }
            // something went wrong, show form with error
            return View(model);
        }


    }
}
