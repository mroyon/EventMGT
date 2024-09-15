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

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Gen_UnitController
    /// </summary>
     [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Gen_UnitController : BaseController
    {
        private readonly IGen_UnitUseCase _gen_UnitUseCase;
        private readonly Gen_UnitPresenter _gen_UnitPresenter;
        private readonly ICacheProvider _cacheProvider;


        
        

        private readonly ILogger<Gen_UnitController> _logger;
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
        /// Gen_UnitController
        /// </summary>
        /// <param name="gen_UnitUseCase"></param>
        /// <param name="gen_UnitPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
       
        public Gen_UnitController(
            IGen_UnitUseCase gen_UnitUseCase,
            Gen_UnitPresenter gen_UnitPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            ,ICacheProvider cacheProvider
            
             
            )
        {
            _gen_UnitUseCase = gen_UnitUseCase;
            _gen_UnitPresenter = gen_UnitPresenter;
            _logger = loggerFactory.CreateLogger<Gen_UnitController>();
            _schemeProvider = schemeProvider;
            
            
             
             
             
            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;
            
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingGen_Unit
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingGen_Unit(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_Unit/LandingGen_Unit", new gen_unitEntity());
        }

        /// <summary>
        /// ListGen_Unit
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListGen_Unit(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                gen_unitEntity objrequest = new gen_unitEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Gen_Unit";
                await _gen_UnitUseCase.GetListView(new Gen_UnitRequest(objrequest), _gen_UnitPresenter);
                return Json(_gen_UnitPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddGen_Unit
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddGen_Unit(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_Unit/AddGen_Unit", new gen_unitEntity());
        }

        /// <summary>
        /// POST AddGen_Unit
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGen_Unit([FromBody] gen_unitEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_UnitUseCase.Save(new Gen_UnitRequest(request), _gen_UnitPresenter);
            return _gen_UnitPresenter.ContentResult;
        }

        /// <summary>
        /// Get View EditGen_Unit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditGen_Unit([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_unitEntity objEntity = new gen_unitEntity();
            objEntity.unitid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("unitid", input).ToString());
            await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objEntity), _gen_UnitPresenter);
            objEntity = _gen_UnitPresenter.Result as gen_unitEntity;
            
            
            
            
            return View("../General/Gen_Unit/EditGen_Unit", _gen_UnitPresenter.Result);
        }

        /// <summary>
        /// Post EditGen_Unit
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGen_Unit([FromBody] gen_unitEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_UnitUseCase.Update(new Gen_UnitRequest(request), _gen_UnitPresenter);
            return _gen_UnitPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleGen_Unit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleGen_Unit([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_unitEntity objEntity = new gen_unitEntity();
            objEntity.unitid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("unitid", input).ToString());
            await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objEntity), _gen_UnitPresenter);
            objEntity = _gen_UnitPresenter.Result as gen_unitEntity;
            
            
            
            return View("../General/Gen_Unit/GetSingleGen_Unit", _gen_UnitPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteGen_Unit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_Unit([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_unitEntity objEntity = new gen_unitEntity();
            objEntity.unitid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("unitid", input).ToString());
            await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objEntity), _gen_UnitPresenter);
            objEntity = _gen_UnitPresenter.Result as gen_unitEntity;
            
            
            
            return View("../General/Gen_Unit/DeleteGen_Unit", _gen_UnitPresenter.Result);
        }

        /// <summary>
        /// Post DeleteGen_Unit
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_Unit([FromBody] gen_unitEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
           /*				 ModelState.Remove("unitid");
				 ModelState.Remove("unit");
				 ModelState.Remove("unitcode");
				 ModelState.Remove("ex_nvarchar3");
*/
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_UnitUseCase.Delete(new Gen_UnitRequest(request), _gen_UnitPresenter);
            return _gen_UnitPresenter.ContentResult;
        }
        
      
        
        /// <summary>
		/// GetDataForDropDown Gen_Unit
			/// </summary>
			/// <param name="request"></param>
			/// <returns></returns>
			[HttpPost]
			[AutoValidateAntiforgeryToken]
			public async Task<IActionResult> GetDataForDropDowndGen_Unit([FromBody] S2Parameters request)
			{
				try
				{
					gen_unitEntity objrequest = new gen_unitEntity();
					objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
					objrequest.BaseSecurityParam = request.BaseSecurityParam;
					objrequest.CurrentPage = request.s2PageNum.GetValueOrDefault(1);
					objrequest.PageSize = request.s2PageSize.GetValueOrDefault(10);
					objrequest.SortExpression = " unit asc ";
					objrequest.strCommonSerachParam = request.s2SearchTerm;
					objrequest.ControllerName = "Gen_Unit";
					await _gen_UnitUseCase.GetDataForDropDown(new Gen_UnitRequest(objrequest), _gen_UnitPresenter);
					return Json(_gen_UnitPresenter.Result);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

        
    }
}
