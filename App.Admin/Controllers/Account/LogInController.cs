using App.Common.GuardToolkit;
using App.DomainModels.ViewModels.Identity;
using App.DomainModels.ViewModels.Settings;
using App.DomainServices.Identity;
using App.DomainServices.Identity.Contracts;
using DNTBreadCrumb.Core;
using DNTCaptcha.Core;
using DNTCaptcha.Core.Providers;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace App.Admin.Controllers
{

    [Route("LogIn")]
    public class LogInController : Controller
    {
        private readonly ILogger<LogInController> _logger;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IApplicationUserManager _userManager;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;

        public LogInController(
            IApplicationSignInManager signInManager,
            IApplicationUserManager userManager,
            IOptionsSnapshot<SiteSettings> siteOptions,
            ILogger<LogInController> logger)
        {
            _signInManager = signInManager;
            _signInManager.CheckArgumentIsNull(nameof(_signInManager));

            _userManager = userManager;
            _userManager.CheckArgumentIsNull(nameof(_userManager));

            _siteOptions = siteOptions;
            _siteOptions.CheckArgumentIsNull(nameof(_siteOptions));

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(_logger));
        }
        [BreadCrumb(Title = "ایندکس", Order = 1)]
        [NoBrowserCache]
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(ErrorMessage = "لطفا کد امنیتی را وارد کنید.",
                           IsNumericErrorMessage = "مقدار باید عدد باشد.",
                           CaptchaGeneratorLanguage = Language.Persian)]
        public async Task<IActionResult> Index(LoginViewModel vm, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(vm.Username);
                if (user==null)
                {
                    ModelState.AddModelError(string.Empty, "نام کاربری و یا کلمه‌ی عبور وارد شده معتبر نیستند.");
                    return View(vm);
                }

                if (!user.IsActive)
                {
                    ModelState.AddModelError(string.Empty, "اکانت شما غیرفعال شده‌است.");
                    return View(vm);
                }

                if (_siteOptions.Value.EnableEmailConfirmation &&
                    !await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "لطفا به پست الکترونیک خود مراجعه کرده و ایمیل خود را تائید کنید!");
                    return View(vm);
                }

                var result =await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, vm.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _logger.LogInformation(1, $"{vm.Username} logged in.");
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning(2, $"{model.Username} قفل شده‌است.");
                //    return View("~/Areas/Identity/Views/TwoFactor/Lockout.cshtml");
                //}

                //if (result.IsNotAllowed)
                //{
                //    ModelState.AddModelError(string.Empty, "عدم دسترسی ورود.");
                //    return View(model);
                //}

                ModelState.AddModelError(string.Empty, "نام کاربری و یا کلمه‌ی عبور وارد شده معتبر نیستند.");
                return View(vm);
            }

            // If we got this far, something failed, redisplay form
            return View(vm);
        }
    }
}