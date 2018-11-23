﻿using App.Common.GuardToolkit;
using App.DomainModels.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.DomainServices.Identity.Contracts
{
    public class ApplicationSignInManager :
        SignInManager<User>,
        IApplicationSignInManager
    {
        private readonly IApplicationUserManager _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserClaimsPrincipalFactory<User> _claimsFactory;
        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly ILogger<ApplicationSignInManager> _logger;
        private readonly IAuthenticationSchemeProvider _schemes;

        public ApplicationSignInManager(
            IApplicationUserManager userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<ApplicationSignInManager> logger,
            IAuthenticationSchemeProvider schemes)
            : base((UserManager<User>)userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
            _userManager = userManager;
            _userManager.CheckArgumentIsNull(nameof(_userManager));

            _contextAccessor = contextAccessor;
            _contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));

            _claimsFactory = claimsFactory;
            _claimsFactory.CheckArgumentIsNull(nameof(_claimsFactory));

            _optionsAccessor = optionsAccessor;
            _optionsAccessor.CheckArgumentIsNull(nameof(_optionsAccessor));

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(_logger));

            _schemes = schemes;
            _schemes.CheckArgumentIsNull(nameof(_schemes));
        }

        #region BaseClass

        Task<bool> IApplicationSignInManager.IsLockedOut(User user)
        {
            return base.IsLockedOut(user);
        }

        Task<SignInResult> IApplicationSignInManager.LockedOut(User user)
        {
            return base.LockedOut(user);
        }

        Task<SignInResult> IApplicationSignInManager.PreSignInCheck(User user)
        {
            return base.PreSignInCheck(user);
        }

        Task IApplicationSignInManager.ResetLockout(User user)
        {
            return base.ResetLockout(user);
        }

        Task<SignInResult> IApplicationSignInManager.SignInOrTwoFactorAsync(User user, bool isPersistent, string loginProvider, bool bypassTwoFactor)
        {
            return base.SignInOrTwoFactorAsync(user, isPersistent, loginProvider, bypassTwoFactor);
        }

        #endregion

        #region CustomMethods

        public bool IsCurrentUserSignedIn()
        {
            return IsSignedIn(_contextAccessor.HttpContext.User);
        }

        public Task<User> ValidateCurrentUserSecurityStampAsync()
        {
            return ValidateSecurityStampAsync(_contextAccessor.HttpContext.User);
        }

        #endregion
    }
}
