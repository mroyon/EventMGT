﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Web.Core.Frame.CustomIdentityManagers;
using CLL.Localization;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.Presenters;
using BDO.Core.DataAccessObjects.SecurityModels;
using BDO.Core.DataAccessObjects.CommonEntities;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// OwinUser Controller
    /// </summary>
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class OwinUserController : BaseController
    {
        private readonly IAuth_UseCase _auth_UseCase;
        private readonly Auth_Presenter _auth_UsePresenter;

        private readonly IOwin_UserUseCase _owin_UserUseCase;
        private readonly Owin_UserPresenter _owin_UserPresenter;

        private readonly ApplicationUserManager<owin_userEntity> _userManager;
        private readonly ApplicationSignInManager<owin_userEntity> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        /// <summary>
        /// OwinUserController
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
        public OwinUserController(
                        IAuth_UseCase auth_UseCase,
                        Auth_Presenter auth_UsePresenter,
            IOwin_UserUseCase owin_UserUseCase,
            Owin_UserPresenter owin_UserPresenter,

            ApplicationUserManager<owin_userEntity> userManager,
            ApplicationSignInManager<owin_userEntity> signInManager,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider)

        {
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
        }

        /// <summary>
        /// GetListView
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingOwinUser(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../Security/Owin_User/LandingOwin_User", new owin_userEntity());
        }

        /// <summary>
        /// ListOwinUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListOwinUser(DtParameters request)
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
                objrequest.ControllerName = "OwinUser";
                await _owin_UserUseCase.GetListView(new Owin_UserRequest(objrequest), _owin_UserPresenter);
                return Json(_owin_UserPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// AddOwinUser
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AddOwinUser(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../Security/Owin_User/AddOwin_User", new owin_userEntity());
        }

        /// <summary>
        /// AddOwinUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOwinUser([FromBody] owin_userEntity request)
        {
            ModelState.Remove("applicationid");
            ModelState.Remove("masteruserid");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("passwordsalt");
            ModelState.Remove("passwordkey");
            ModelState.Remove("passwordvector");
            ModelState.Remove("masprivatekey");
            ModelState.Remove("maspublickey");
            ModelState.Remove("isanonymous");
            ModelState.Remove("loweredusername");
            ModelState.Remove("emailaddress");
            ModelState.Remove("username");
            ModelState.Remove("loweredusername");
            ModelState.Remove("newpassword");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.Save(new Owin_UserRequest(request), _owin_UserPresenter);
            return _owin_UserPresenter.ContentResult;
        }

        /// <summary>
        /// EditOwinUser
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditOwinUser([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = new Guid(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            return View("../Security/Owin_User/EditOwin_User", _owin_UserPresenter.Result);
        }

        /// <summary>
        /// EditOwinUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOwinUser([FromBody] owin_userEntity request)
        {
            ModelState.Remove("applicationid");
            ModelState.Remove("masteruserid");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("passwordsalt");
            ModelState.Remove("passwordkey");
            ModelState.Remove("passwordvector");
            ModelState.Remove("masprivatekey");
            ModelState.Remove("maspublickey");
            ModelState.Remove("isanonymous");
            ModelState.Remove("loweredusername");
            ModelState.Remove("emailaddress");
            ModelState.Remove("username");
            ModelState.Remove("loweredusername");
            ModelState.Remove("newpassword");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.Update(new Owin_UserRequest(request), _owin_UserPresenter);
            return _owin_UserPresenter.ContentResult;
        }

        /// <summary>
        /// ViewOwinUser
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleOwinUser([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = new Guid(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            return View("../Security/Owin_User/GetSingleOwin_User", _owin_UserPresenter.Result);
        }

        /// <summary>
        /// DeleteOwinUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOwinUser([FromBody] owin_userEntity request)
        {
            ModelState.Remove("applicationid");
            ModelState.Remove("masteruserid");
            ModelState.Remove("confirmpassword");
            ModelState.Remove("passwordsalt");
            ModelState.Remove("passwordkey");
            ModelState.Remove("passwordvector");
            ModelState.Remove("masprivatekey");
            ModelState.Remove("maspublickey");
            ModelState.Remove("isanonymous");
            ModelState.Remove("loweredusername");
            ModelState.Remove("emailaddress");
            ModelState.Remove("username");
            ModelState.Remove("loweredusername");
            ModelState.Remove("newpassword");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.Delete(new Owin_UserRequest(request), _owin_UserPresenter);
            return _owin_UserPresenter.ContentResult;
        }
    }
}