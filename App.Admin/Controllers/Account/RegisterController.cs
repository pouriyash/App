using App.Common.GuardToolkit;
using App.DomainModels.Entities.Identity;
using App.DomainModels.ViewModels.Identity;
using App.DomainModels.ViewModels.Settings;
using App.DomainServices.Identity.Contracts;
using DNTBreadCrumb.Core;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Identity;
using DNTCaptcha.Core.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace App.Admin.Controllers
{
    [Route("Register")]
    public class RegisterController:Controller
    {
        //private readonly IEmailSender _emailSender;
        private readonly ILogger<RegisterController> _logger;
        private readonly IApplicationUserManager _userManager;
        private readonly IPasswordValidator<User> _passwordValidator;
        private readonly IUserValidator<User> _userValidator;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;

        public RegisterController(
            IApplicationUserManager userManager,
            IPasswordValidator<User> passwordValidator,
            IUserValidator<User> userValidator,
            //IEmailSender emailSender,
            IOptionsSnapshot<SiteSettings> siteOptions,
            ILogger<RegisterController> logger)
        {
            _userManager = userManager;
            _userManager.CheckArgumentIsNull(nameof(_userManager));

            _passwordValidator = passwordValidator;
            _passwordValidator.CheckArgumentIsNull(nameof(_passwordValidator));

            _userValidator = userValidator;
            _userValidator.CheckArgumentIsNull(nameof(_userValidator));

            //_emailSender = emailSender;
            //_emailSender.CheckArgumentIsNull(nameof(_emailSender));

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(_logger));

            _siteOptions = siteOptions;
            _siteOptions.CheckArgumentIsNull(nameof(_siteOptions));
        }
        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateDNTCaptcha(ErrorMessage = "لطفا کد امنیتی را وارد کنید.",
                            IsNumericErrorMessage = "مقدار باید عدد باشد..",
                            CaptchaGeneratorLanguage = Language.Persian)]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                {
                    _logger.LogInformation(3, $"{user.UserName} created a new account with password.");

                    //if (_siteOptions.Value.EnableEmailConfirmation)
                    //{
                    //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //    //ControllerExtensions.ShortControllerName<RegisterController>(), //todo: use everywhere .................

                    //    await _emailSender.SendEmailAsync(
                    //       email: user.Email,
                    //       subject: "لطفا اکانت خود را تائید کنید",
                    //       viewNameOrPath: "~/Areas/Identity/Views/EmailTemplates/_RegisterEmailConfirmation.cshtml",
                    //       model: new RegisterEmailConfirmationViewModel
                    //       {
                    //           User = user,
                    //           EmailConfirmationToken = code,
                    //           EmailSignature = _siteOptions.Value.Smtp.FromName,
                    //           MessageDateTime = DateTime.UtcNow.ToLongPersianDateTimeString()
                    //       });

                    //    return RedirectToAction(nameof(ConfirmYourEmail));
                    //}
                    return RedirectToAction("ConfirmedRegisteration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        //[BreadCrumb(Title = "تائیدیه ایمیل", Order = 1)]
        //public IActionResult ConfirmedRegisteration()
        //{
        //    return View();
        //}
    }
}