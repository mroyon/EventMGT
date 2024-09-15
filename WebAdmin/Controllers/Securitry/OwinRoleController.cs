﻿using System;
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
using Web.Core.Frame.UseCases;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Owin_RoleController
    /// </summary>
    [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Owin_RoleController : BaseController
    {
        private readonly IOwin_RoleUseCase _owin_RoleUseCase;
        private readonly Owin_RolePresenter _owin_RolePresenter;
        private readonly ICacheProvider _cacheProvider;


        
        

        private readonly ILogger<Owin_RoleController> _logger;
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
        /// Owin_RoleController
        /// </summary>
        /// <param name="owin_RoleUseCase"></param>
        /// <param name="owin_RolePresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
       
        public Owin_RoleController(
            IOwin_RoleUseCase owin_RoleUseCase,
            Owin_RolePresenter owin_RolePresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            ,ICacheProvider cacheProvider
            
             
            )
        {
            _owin_RoleUseCase = owin_RoleUseCase;
            _owin_RolePresenter = owin_RolePresenter;
            _logger = loggerFactory.CreateLogger<Owin_RoleController>();
            _schemeProvider = schemeProvider;
            
            
             
             
             
            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;
            
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingOwin_Role
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingOwin_Role(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../Security/Owin_Role/LandingOwin_Role", new owin_roleEntity());
        }

        /// <summary>
        /// ListOwin_Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListOwin_Role(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                owin_roleEntity objrequest = new owin_roleEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression =  request.SortOrder + " " + (request.Order[0].Dir.ToString() == "Asc" ? "Desc" : request.Order[0].Dir);
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Owin_Role";
                await _owin_RoleUseCase.GetListView(new Owin_RoleRequest(objrequest), _owin_RolePresenter);
                return Json(_owin_RolePresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddOwin_Role
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddOwin_Role(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../Security/Owin_Role/AddOwin_Role", new owin_roleEntity());
        }

        /// <summary>
        /// POST AddOwin_Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOwin_Role([FromBody] owin_roleEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_RoleUseCase.Save(new Owin_RoleRequest(request), _owin_RolePresenter);
            return _owin_RolePresenter.ContentResult;
        }

        /// <summary>
        /// Get View EditOwin_Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditOwin_Role([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_roleEntity objEntity = new owin_roleEntity();
            objEntity.roleid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("roleid", input).ToString());
            await _owin_RoleUseCase.GetSingle(new Owin_RoleRequest(objEntity), _owin_RolePresenter);
            objEntity = _owin_RolePresenter.Result as owin_roleEntity;
            
            
            
            
            return View("../Security/Owin_Role/EditOwin_Role", _owin_RolePresenter.Result);
        }

        /// <summary>
        /// Post EditOwin_Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOwin_Role([FromBody] owin_roleEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_RoleUseCase.Update(new Owin_RoleRequest(request), _owin_RolePresenter);
            return _owin_RolePresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleOwin_Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleOwin_Role([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_roleEntity objEntity = new owin_roleEntity();
            objEntity.roleid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("roleid", input).ToString());
            await _owin_RoleUseCase.GetSingle(new Owin_RoleRequest(objEntity), _owin_RolePresenter);
            objEntity = _owin_RolePresenter.Result as owin_roleEntity;
            
            
            
            return View("../Security/Owin_Role/GetSingleOwin_Role", _owin_RolePresenter.Result);
        }

        /// <summary>
        /// Get View DeleteOwin_Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteOwin_Role([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            owin_roleEntity objEntity = new owin_roleEntity();
            objEntity.roleid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("roleid", input).ToString());
            await _owin_RoleUseCase.GetSingle(new Owin_RoleRequest(objEntity), _owin_RolePresenter);
            objEntity = _owin_RolePresenter.Result as owin_roleEntity;
            
            
            
            return View("../Security/Owin_Role/DeleteOwin_Role", _owin_RolePresenter.Result);
        }

        /// <summary>
        /// Post DeleteOwin_Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteOwin_Role([FromBody] owin_roleEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
           /*				 ModelState.Remove("roleid");
				 ModelState.Remove("rolename");
				 ModelState.Remove("description");
*/
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _owin_RoleUseCase.Delete(new Owin_RoleRequest(request), _owin_RolePresenter);
            return _owin_RolePresenter.ContentResult;
        }



        /// <summary>
        /// GetDataForDropDown Owin_Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetDataForDropDowndOwin_Role([FromBody] S2Parameters request)
        {
            try
            {
                owin_roleEntity objrequest = new owin_roleEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.s2PageNum.GetValueOrDefault(1);
                objrequest.PageSize = request.s2PageSize.GetValueOrDefault(10);
                objrequest.SortExpression = " rolename asc ";
                objrequest.strCommonSerachParam = request.s2SearchTerm;
                objrequest.ControllerName = "Owin_Role";
                await _owin_RoleUseCase.GetDataForDropDown(new Owin_RoleRequest(objrequest), _owin_RolePresenter);
                return Json(_owin_RolePresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
