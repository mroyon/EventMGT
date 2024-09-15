using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using CLL.Localization;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.Presenters;
using Microsoft.Extensions.Configuration;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.CommonEntities;
using WebAdmin.Providers;
using Newtonsoft.Json;
using BDO.Core.DataAccessObjects.SecurityModels;
using AppConfig.EncryptionHandler;
using System.Collections.Generic;
using Web.Core.Frame.UseCases;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using CLL.LLClasses.SecurityModels;

namespace WebAdmin.Controllers.Securitry
{
    /// <summary>
    /// Owin_UserController
    /// </summary>
    [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Owin_UserController : BaseController
    {
        private readonly IOwin_UserUseCase _owin_UserUseCase;
        private readonly Owin_UserPresenter _owin_UserPresenter;
        private readonly ICacheProvider _cacheProvider;

        private readonly IAuth_UseCase _auth_UseCase;
        private readonly Auth_Presenter _auth_UsePresenter;

        private readonly IOwin_RoleUseCase _owin_RoleUseCase;
        private readonly Owin_RolePresenter _owin_RolePresenter;

        private readonly IOwin_UserRoleUseCase _owin_UserRoleUseCase;
        private readonly Owin_UserRolePresenter _owin_UserRolePresenter;

        private readonly ILogger<Owin_UserController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly IAuthenticationSchemeProvider _schemeProvider;


        //to Enable SignalR Inj
        //private readonly IHubContext<HubUserContext> _hubuserContext;
        //private readonly IUserConnectionManager _userConnectionManager;

        /// <summary>
        /// _configuration
        /// </summary>
        public IConfiguration _configuration { get; }

        /// <summary>
        /// Owin_UserController
        /// </summary>
        /// <param name="auth_UseCase"></param>
        /// <param name="auth_UsePresenter"></param>
        /// <param name="owin_UserUseCase"></param>
        /// <param name="owin_UserPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
        /// <param name="owin_RoleUseCase"></param>
        /// <param name="owin_RolePresenter"></param>
        /// <param name="owin_UserRoleUseCase"></param>
        /// <param name="owin_UserRolePresenter"></param>
        public Owin_UserController(
            IAuth_UseCase auth_UseCase,
            Auth_Presenter auth_UsePresenter,
            IOwin_UserUseCase owin_UserUseCase,
            Owin_UserPresenter owin_UserPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            , ICacheProvider cacheProvider
            , IOwin_RoleUseCase owin_RoleUseCase
            , Owin_RolePresenter owin_RolePresenter
            , IOwin_UserRoleUseCase owin_UserRoleUseCase
            , Owin_UserRolePresenter owin_UserRolePresenter
            )
        {
            _auth_UseCase = auth_UseCase;
            _auth_UsePresenter = auth_UsePresenter;

            _owin_UserUseCase = owin_UserUseCase;
            _owin_UserPresenter = owin_UserPresenter;

            _owin_RoleUseCase = owin_RoleUseCase;
            _owin_RolePresenter = owin_RolePresenter;

            _owin_UserRoleUseCase = owin_UserRoleUseCase;
            _owin_UserRolePresenter = owin_UserRolePresenter;

            _logger = loggerFactory.CreateLogger<Owin_UserController>();
            _schemeProvider = schemeProvider;





            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingOwin_User
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingOwin_User(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../Security/Owin_User/LandingOwin_User", new owin_userEntity());
        }

        /// <summary>
        /// ListOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListOwin_User(dtOwinUser request)
        {
            try
            {
                owin_userEntity ou = new owin_userEntity();
                ou.status = "";

                var draw = request.Draw;
                owin_userEntity objrequest = new owin_userEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = (request.SortOrder == "masteruserid" ? "MasterUserID" : request.SortOrder) + " " + (request.Order[0].Dir.ToString() == "Asc" ? "Desc" : request.Order[0].Dir);
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Owin_User";
                objrequest.username = request.username;
                objrequest.emailaddress = request.emailaddress;
                objrequest.loweredusername = request.loweredusername;
                objrequest.emailaddress = request.emailaddress;
                objrequest.isreviewed = request.isreviewed;
                objrequest.locked = request.locked;
                objrequest.fromdate = request.fromdate;
                objrequest.todate = request.todate;
                await _owin_UserUseCase.GetListView(new Owin_UserRequest(objrequest), _owin_UserPresenter);
                return Json(_owin_UserPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddOwin_User
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddOwin_User(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }

            await _owin_RoleUseCase.GetAll(new Owin_RoleRequest(new owin_roleEntity { }), _owin_RolePresenter);
            List<owin_roleEntity> rolelist = _owin_RolePresenter.Result as List<owin_roleEntity>;

            ViewBag.RoleList = (List<SelectListItem>)rolelist.ToList().OrderBy(p => p.roleid).Select(a =>
                new SelectListItem
                {
                    Text = a.rolename,
                    Value = a.roleid.ToString()
                }
            ).ToList();
            return View("../Security/Owin_User/AddOwin_User", new owin_userEntity());
        }

        /// <summary>
        /// POST AddOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOwin_User([FromBody] owin_userEntity request)
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
            ModelState.Remove("newpassword");
            ModelState.Remove("newemailaddress");
            ModelState.Remove("loweredusername");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            request.isanonymous = false;

            (string publicKey, string privateKey) rsaKey = Encipher.GenerateRSAKeyPair();
            request.masprivatekey = rsaKey.privateKey;
            request.maspublickey = rsaKey.publicKey;

            await _owin_UserUseCase.Save(new Owin_UserRequest(request), _owin_UserPresenter);
            return Json(_owin_UserPresenter.ContentResult);
        }

        /// <summary>
        /// Get View EditOwin_User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditOwin_User([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = Guid.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            objEntity = _owin_UserPresenter.Result as owin_userEntity;




            return View("../Security/Owin_User/EditOwin_User", _owin_UserPresenter.Result);
        }

        /// <summary>
        /// Post EditOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOwin_User([FromBody] owin_userEntity request)
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
            ModelState.Remove("newpassword");
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");


            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.Update(new Owin_UserRequest(request), _owin_UserPresenter);
            return _owin_UserPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleOwin_User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleOwin_User([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = Guid.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingleExt(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            objEntity = _owin_UserPresenter.Result as owin_userEntity;

            var dataowin_role = new { Id = objEntity.roleid, Text = objEntity.rolename };
            ViewBag.preloadedDataowin_role = JsonConvert.SerializeObject(dataowin_role);

            return View("../Security/Owin_User/GetSingleOwin_User", _owin_UserPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteOwin_User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteOwin_User([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = Guid.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            objEntity = _owin_UserPresenter.Result as owin_userEntity;



            return View("../Security/Owin_User/DeleteOwin_User", _owin_UserPresenter.Result);
        }

        /// <summary>
        /// Post DeleteOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteOwin_User([FromBody] owin_userEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            /*				 ModelState.Remove("applicationid");
                  ModelState.Remove("userid");
                  ModelState.Remove("masteruserid");
                  ModelState.Remove("username");
                  ModelState.Remove("emailaddress");
                  ModelState.Remove("loweredusername");
                  ModelState.Remove("mobilenumber");
                  ModelState.Remove("userprofilephoto");
                  ModelState.Remove("isanonymous");
                  ModelState.Remove("ischildenable");
                  ModelState.Remove("masprivatekey");
                  ModelState.Remove("maspublickey");
                  ModelState.Remove("password");
                  ModelState.Remove("passwordsalt");
                  ModelState.Remove("passwordkey");
                  ModelState.Remove("passwordvector");
                  ModelState.Remove("mobilepin");
                  ModelState.Remove("passwordquestion");
                  ModelState.Remove("passwordanswer");
                  ModelState.Remove("approved");
                  ModelState.Remove("locked");
                  ModelState.Remove("lastlogindate");
                  ModelState.Remove("lastpasschangeddate");
                  ModelState.Remove("lastlockoutdate");
                  ModelState.Remove("failedpasswordattemptcount");
                  ModelState.Remove("comment");
                  ModelState.Remove("lastactivitydate");
                  ModelState.Remove("isapproved");
                  ModelState.Remove("approvedby");
                  ModelState.Remove("approvedbyusername");
                  ModelState.Remove("approveddate");
                  ModelState.Remove("isemailconfirmed");
                  ModelState.Remove("emailconfirmationbyuserdate");
                  ModelState.Remove("twofactorenable");
                  ModelState.Remove("ismobilenumberconfirmed");
                  ModelState.Remove("mobilenumberconfirmedbyuserdate");
                  ModelState.Remove("securitystamp");
                  ModelState.Remove("concurrencystamp");
                  ModelState.Remove("webuseronly");
 */
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.Delete(new Owin_UserRequest(request), _owin_UserPresenter);
            return _owin_UserPresenter.ContentResult;
        }


        #region User Review
        /// <summary>
        /// Get View ReviewOwin_User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ReviewOwin_User([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = Guid.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            objEntity = _owin_UserPresenter.Result as owin_userEntity;




            return View("../Security/Owin_User/ReviewOwin_User", _owin_UserPresenter.Result);
        }
        /// <summary>
        /// Post ReviewOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReviewOwin_User([FromBody] owin_userEntity request)
        {
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
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.ReviewOwin_User(new Owin_UserRequest(request), _owin_UserPresenter);
            return _owin_UserPresenter.ContentResult;
        }
        #endregion

        #region User Lock
        /// <summary>
        /// Get View LockOwin_User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> LockOwin_User([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = Guid.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            objEntity = _owin_UserPresenter.Result as owin_userEntity;




            return View("../Security/Owin_User/LockOwin_User", _owin_UserPresenter.Result);
        }
        /// <summary>
        /// Post ReviewOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LockOwin_User([FromBody] owin_userEntity request)
        {
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
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.LockOwin_User(new Owin_UserRequest(request), _owin_UserPresenter);
            return _owin_UserPresenter.ContentResult;
        }
        #endregion

        #region Password Reset
        /// <summary>
        /// Get View PasswordResetOwin_User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> PasswordResetOwin_User([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = Guid.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            objEntity = _owin_UserPresenter.Result as owin_userEntity;




            return View("../Security/Owin_User/PasswordResetOwin_User", _owin_UserPresenter.Result);
        }
        /// <summary>
        /// Post PasswordResetOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PasswordResetOwin_User([FromBody] owin_userEntity request)
        {
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
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.PasswordResetOwin_User(new Auth_Request(request), _auth_UsePresenter);
            //await _auth_UseCase.ResetPassword(new Auth_Request(request), _auth_UsePresenter);
            return _auth_UsePresenter.ContentResult;
        }
        #endregion

        #region User Review
        /// <summary>
        /// Get View EmailResetOwin_User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EmailResetOwin_User([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = Guid.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            objEntity = _owin_UserPresenter.Result as owin_userEntity;




            return View("../Security/Owin_User/EmailResetOwin_User", _owin_UserPresenter.Result);
        }
        /// <summary>
        /// Post EmailResetOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmailResetOwin_User([FromBody] owin_userEntity request)
        {
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
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_UserUseCase.EmailResetOwin_User(new Owin_UserRequest(request), _owin_UserPresenter);
            return _owin_UserPresenter.ContentResult;
        }
        #endregion

        #region User Review
        /// <summary>
        /// Get View UpdateRoleOwin_User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> UpdateRoleOwin_User([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_userEntity objEntity = new owin_userEntity();
            objEntity.userid = Guid.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("userid", input).ToString());
            await _owin_UserUseCase.GetSingleExt(new Owin_UserRequest(objEntity), _owin_UserPresenter);
            objEntity = _owin_UserPresenter.Result as owin_userEntity;

            //owin_roleEntity objgen_owinroleEntity = new owin_roleEntity();
            //objgen_owinroleEntity.roleid = objEntity.roleid;
            //await _owin_RoleUseCase.GetSingle(new Owin_RoleRequest(objgen_owinroleEntity), _owin_RolePresenter);
            //objgen_owinroleEntity = (owin_roleEntity)_owin_RolePresenter.Result;
            var dataowin_role = new { Id = objEntity.roleid, Text = objEntity.rolename };
            ViewBag.preloadedDataowin_role = JsonConvert.SerializeObject(dataowin_role);



            return View("../Security/Owin_User/UpdateRoleOwin_User", _owin_UserPresenter.Result);
        }
        /// <summary>
        /// Post UpdateRoleOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoleOwin_User([FromBody] owin_userEntity request)
        {
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
            ModelState.Remove("newemailaddress");
            ModelState.Remove("pkeyex");
            ModelState.Remove("roleid");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            owin_userroleEntity objuserrole = new owin_userroleEntity();
            objuserrole.masteruserid = request.masteruserid;
            await _owin_UserRoleUseCase.GetSingle(new Owin_UserRoleRequest(objuserrole), _owin_UserRolePresenter);
            objuserrole = _owin_UserRolePresenter.Result as owin_userroleEntity;

            if (objuserrole != null)
            {
                objuserrole.roleid = request.roleid;
            }
            await _owin_UserRoleUseCase.Update(new Owin_UserRoleRequest(objuserrole), _owin_UserRolePresenter);
            return _owin_UserRolePresenter.ContentResult;

            //await _owin_UserUseCase.ReviewOwin_User(new Owin_UserRequest(request), _owin_UserPresenter);
            //return _owin_UserPresenter.ContentResult;
        }
        #endregion

        /// <summary>
        /// GetDataForDropDowndOwin_User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetDataForDropDowndOwin_User([FromBody] S2Parameters request)
        {
            try
            {
                owin_userEntity objrequest = new owin_userEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.s2PageNum.GetValueOrDefault(1);
                objrequest.PageSize = request.s2PageSize.GetValueOrDefault(10);
                objrequest.SortExpression = " username asc ";
                objrequest.strCommonSerachParam = request.s2SearchTerm;
                objrequest.ControllerName = "Owin_User";

                objrequest.roleid = !string.IsNullOrEmpty(request.s2ParamParentkey) ? Convert.ToInt64(request.s2ParamParentkey) : null;

                await _owin_UserUseCase.GetDataForDropDown(new Owin_UserRequest(objrequest), _owin_UserPresenter);
                return Json(_owin_UserPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
