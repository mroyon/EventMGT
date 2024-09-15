﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Web.Core.Frame.CustomIdentityManagers;
using CLL.Localization;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.Presenters;
using BDO.Core.DataAccessObjects.SecurityModels;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.CommonEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using WebAdmin.Providers;
using BDO.DataAccessObjects.ExtendedEntities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Web.Core.Frame.Dto.UseCaseRequests;
using Web.Core.Frame.UseCases;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Account
    /// </summary>
    [Authorize(Policy = "defaultpolicy")]
    [AutoValidateAntiforgeryToken]
    public class AccountController : BaseController
    {



        private readonly IAuth_UseCase _auth_UseCase;
        private readonly Auth_Presenter _auth_UsePresenter;

        private readonly ICacheProvider _cacheProvider;
        private readonly IOwin_UserUseCase _owin_UserUseCase;
        private readonly Owin_UserPresenter _owin_UserPresenter;

        private readonly ApplicationUserManager<owin_userEntity> _userManager;
        private readonly ApplicationSignInManager<owin_userEntity> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly HostingDomainSettings _hostingDomainSettings;
        private readonly IConfiguration _config;

        /// <summary>
        /// AccountController
        /// </summary>
        /// <param name="auth_UseCase"></param>
        /// <param name="auth_UsePresenter"></param>
        /// <param name="owin_UserUseCase"></param>
        /// <param name="owin_UserPresenter"></param>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>
        public AccountController(
                        IAuth_UseCase auth_UseCase,
                        Auth_Presenter auth_UsePresenter,
            IOwin_UserUseCase owin_UserUseCase,
            Owin_UserPresenter owin_UserPresenter,
            IConfiguration config,

            ApplicationUserManager<owin_userEntity> userManager,
            ApplicationSignInManager<owin_userEntity> signInManager,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider,
          ICacheProvider cacheProvider)

        {
            _cacheProvider = cacheProvider;
            _config = config;
            _auth_UseCase = auth_UseCase;
            _auth_UsePresenter = auth_UsePresenter;
            _owin_UserUseCase = owin_UserUseCase;
            _owin_UserPresenter = owin_UserPresenter;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _schemeProvider = schemeProvider;
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
            _hostingDomainSettings = _config.GetSection(nameof(HostingDomainSettings)).Get<HostingDomainSettings>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var vm = await BuildLoginViewModelAsync(returnUrl);

            try
            {
                string key = HttpContext.Session.Id;
                AppConfig.HelperClasses.transactioncodeGen objTrans = new AppConfig.HelperClasses.transactioncodeGen();
                string guid = Guid.NewGuid().ToString();
                var str = HttpContext.Session.GetRedis<string>("SessCodeQR");
                if (string.IsNullOrEmpty(str))
                {
                    vm.code = HttpContext.Session.Id + "_" + objTrans.GetRandomAlphaNumericStringForTransactionActivity("SIGQRC", DateTime.Now) + "_" + guid;
                    HttpContext.Session.SetRedis("SessCodeQR", vm.code);
                }
                vm.code = HttpContext.Session.GetRedis<string>("SessCodeQR");
            }
            finally
            {
                //mutex.ReleaseMutex();
            }



            return View(vm);
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] owin_userEntity request)
        {
            var returnUrl = request.ReturnUrl;
            ViewData["ReturnUrl"] = returnUrl;

            ModelState.Remove("passwordquestion");
            ModelState.Remove("passwordkey");
            ModelState.Remove("passwordvector");
            ModelState.Remove("locked");
            ModelState.Remove("approved");
            ModelState.Remove("loweredusername");
            ModelState.Remove("applicationid");
            ModelState.Remove("masteruserid");
            ModelState.Remove("newpassword");
            ModelState.Remove("username");
            ModelState.Remove("isanonymous");
            ModelState.Remove("masprivatekey");
            ModelState.Remove("maspublickey");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("passwordsalt");
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _auth_UseCase.LoginWebRequest(new Auth_Request(request), _auth_UsePresenter);
            return Json(_auth_UsePresenter.ContentResult);
        }



        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout([FromBody] owin_userEntity request)
        {
            var returnUrl = request.ReturnUrl;
            ViewData["ReturnUrl"] = returnUrl;
            ModelState.Remove("emailaddress");
            ModelState.Remove("password");
            ModelState.Remove("passwordquestion");
            ModelState.Remove("passwordkey");
            ModelState.Remove("passwordvector");
            ModelState.Remove("locked");
            ModelState.Remove("approved");
            ModelState.Remove("loweredusername");
            ModelState.Remove("applicationid");
            ModelState.Remove("masteruserid");
            ModelState.Remove("newpassword");
            ModelState.Remove("username");
            ModelState.Remove("isanonymous");
            ModelState.Remove("masprivatekey");
            ModelState.Remove("maspublickey");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("passwordsalt");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            var idp = User?.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
            ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            await _userManager.logoutowin_userlogintrail(claimsIdentity);
            await _signInManager.SignOutAsync();
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());
            var vm = new owin_userEntity
            {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                ClientName = string.Empty,
                SignOutIframeUrl = string.Empty,
            };
            return Json(new AjaxResponse("200", _sharedLocalizer["VERIFY"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"));
        }


        /// <summary>
        /// Get View ForgetPassword
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(string returnUrl)
        {
            var vm = await BuildLoginViewModelAsync(returnUrl);
            return View(vm);
        }

        /// <summary>
        /// Post ForgetPassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword([FromBody] owin_userEntity request)
        {
            var returnUrl = request.ReturnUrl;
            ViewData["ReturnUrl"] = returnUrl;

            ModelState.Remove("passwordquestion");
            ModelState.Remove("password");
            ModelState.Remove("passwordkey");
            ModelState.Remove("passwordvector");
            ModelState.Remove("locked");
            ModelState.Remove("approved");
            ModelState.Remove("loweredusername");
            ModelState.Remove("applicationid");
            ModelState.Remove("masteruserid");
            ModelState.Remove("newpassword");
            ModelState.Remove("username");
            ModelState.Remove("isanonymous");
            ModelState.Remove("masprivatekey");
            ModelState.Remove("maspublickey");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("passwordsalt");
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _auth_UseCase.ForgetPasswordRequest(new Auth_Request(request), _auth_UsePresenter);
            return _auth_UsePresenter.ContentResult;
        }


        /// <summary>
        /// PasswordReset
        /// </summary>
        /// <param name="AUPIOuser"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PasswordReset(string AUPIOuser)
        {
            if (string.IsNullOrEmpty(AUPIOuser))
            {
                ModelState.AddModelError(string.Empty, _sharedLocalizer["INVALID_VERFICATION_CODE"]);
                return View("../Account/InvalidRequest");
            }
            else
            {
                owin_userEntity request = new owin_userEntity();
                request.code = AUPIOuser;
                bool flg = await _auth_UseCase.PasswordRequestAuthTokenValidated(new Auth_Request(request), _auth_UsePresenter);
                if (flg)
                {
                    return View("../Account/PasswordReset", request);
                }
                else
                {
                    return View("../Account/InvalidRequest");
                }
            }
        }


        /// <summary>
        /// PasswordReset
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PasswordResetPost([FromBody] owin_userEntity request)
        {
            var returnUrl = request.ReturnUrl;
            ViewData["ReturnUrl"] = returnUrl;

            ModelState.Remove("passwordquestion");
            ModelState.Remove("passwordkey");
            ModelState.Remove("passwordvector");
            ModelState.Remove("locked");
            ModelState.Remove("approved");
            ModelState.Remove("loweredusername");
            ModelState.Remove("applicationid");
            ModelState.Remove("masteruserid");
            ModelState.Remove("newpassword");
            ModelState.Remove("username");
            ModelState.Remove("isanonymous");
            ModelState.Remove("masprivatekey");
            ModelState.Remove("maspublickey");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("passwordsalt");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");
            ModelState.Remove("newemailaddress");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _auth_UseCase.ResetPassword(new Auth_Request(request), _auth_UsePresenter);
            return _auth_UsePresenter.ContentResult;
        }


        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Account", "Login");
            }
            return ViewComponent("ChangePassword");
        }

        /// <summary>
        /// ChangePasswordPost
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ChangePasswordPost([FromBody] owin_userEntity request)
        {
            var returnUrl = request.ReturnUrl;
            ViewData["ReturnUrl"] = returnUrl;

            ModelState.Remove("passwordquestion");
            ModelState.Remove("passwordkey");
            ModelState.Remove("passwordvector");
            ModelState.Remove("locked");
            ModelState.Remove("approved");
            ModelState.Remove("loweredusername");
            ModelState.Remove("applicationid");
            ModelState.Remove("masteruserid");
            ModelState.Remove("newpassword");
            ModelState.Remove("username");
            ModelState.Remove("isanonymous");
            ModelState.Remove("masprivatekey");
            ModelState.Remove("maspublickey");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("passwordsalt");
            ModelState.Remove("emailaddress");
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            request.username = claimsIdentity.Name;
            request.emailaddress = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;

            await _auth_UseCase.ChangePassword(new Auth_Request(request), _auth_UsePresenter);
            return Json(_auth_UsePresenter.ContentResult.Content);
        }

        //AddUser
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ViewUserList(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Account", "Login");
            }
            return View(new owin_userEntity());
        }


        /// <summary>
        /// LoadUserData
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LoadUserData(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                owin_userEntity objrequest = new owin_userEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                await _owin_UserUseCase.GetListView(new Owin_UserRequest(objrequest), _owin_UserPresenter);

                return _owin_UserPresenter.ContentResult;

                //string JsonString = .Content;
                //Newtonsoft.Json.Linq.JObject json = string.IsNullOrEmpty(JsonString) == true ? null:  Newtonsoft.Json.Linq.JObject.Parse(JsonString);

                //return Json(new { draw = draw, 
                //    recordsFiltered = json != null ? long.Parse(json["recordsFiltered"].ToString()) : 0, 
                //    recordsTotal = json != null ? long.Parse(json["recordsTotal"].ToString()) : 0, 
                //    data = json });

                //return Json(new { draw = draw, recordsFiltered = 0, recordsTotal = JsonString?.ToList().Count() > 0 ? JsonString.ToList()[0]?.RETURN_KEY ?? 0 : 0, data = JsonString });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async Task<owin_userEntity> BuildLoginViewModelAsync(string returnUrl)
        {
            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName ?? x.Name,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;

            return new owin_userEntity
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                emailaddress = "",//context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        private async Task<owin_userEntity> BuildLoginViewModelAsync(owin_userEntity model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.emailaddress = model.emailaddress;
            vm.AllowRememberLogin = model.AllowRememberLogin;
            return vm;
        }


        /// <summary>
        /// BuildLogoutViewModelAsync
        /// </summary>
        /// <param name="logoutId"></param>
        /// <returns></returns>
        private async Task<owin_userEntity> BuildLogoutViewModelAsync(string logoutId)
        {
            var vm = new owin_userEntity { LogoutId = logoutId, ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt };

            if (User?.Identity.IsAuthenticated != true)
            {
                vm.ShowLogoutPrompt = false;
                return vm;
            }
            return vm;
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        /// <summary>
        /// AccessDenied
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
        ///// <summary>
        ///// AccessDenied
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> GenerateQr()
        //{
        //    string dummytext = "Dummy QR Text";
        //    return Ok(dummytext);
        //}

        
       


        
    }
}