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
using Web.Core.Frame.UseCases;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Gen_UserUnitController
    /// </summary>
     [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Gen_UserUnitController : BaseController
    {
        private readonly IGen_UserUnitUseCase _gen_UserUnitUseCase;
        private readonly Gen_UserUnitPresenter _gen_UserUnitPresenter;
        private readonly ICacheProvider _cacheProvider;


        private readonly IGen_UnitUseCase _gen_UnitUseCase;
		private readonly Gen_UnitPresenter _gen_UnitPresenter;


        private readonly IOwin_UserUseCase _owin_UserUseCase;
        private readonly Owin_UserPresenter _owin_UserPresenter;

        private readonly ILogger<Gen_UserUnitController> _logger;
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
        /// Gen_UserUnitController
        /// </summary>
        /// <param name="gen_UserUnitUseCase"></param>
        /// <param name="gen_UserUnitPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
       /// <param name="gen_UnitUseCase"></param>
/// <param name="gen_UnitPresenter"></param>

        public Gen_UserUnitController(
            IGen_UserUnitUseCase gen_UserUnitUseCase,
            Gen_UserUnitPresenter gen_UserUnitPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            ,ICacheProvider cacheProvider
            
             , IGen_UnitUseCase gen_UnitUseCase 
			,  Gen_UnitPresenter gen_UnitPresenter
            ,IOwin_UserUseCase owin_UserUseCase,
            Owin_UserPresenter owin_UserPresenter

            )
        {
            _gen_UserUnitUseCase = gen_UserUnitUseCase;
            _gen_UserUnitPresenter = gen_UserUnitPresenter;
            _logger = loggerFactory.CreateLogger<Gen_UserUnitController>();
            _schemeProvider = schemeProvider;
            
            
             _gen_UnitUseCase = gen_UnitUseCase;
			_gen_UnitPresenter = gen_UnitPresenter;

            _owin_UserUseCase = owin_UserUseCase;
            _owin_UserPresenter = owin_UserPresenter;


            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;
            
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingGen_UserUnit
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingGen_UserUnit(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_UserUnit/LandingGen_UserUnit", new gen_userunitEntity());
        }

        /// <summary>
        /// ListGen_UserUnit
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListGen_UserUnit(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                gen_userunitEntity objrequest = new gen_userunitEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Gen_UserUnit";
                await _gen_UserUnitUseCase.GetListView(new Gen_UserUnitRequest(objrequest), _gen_UserUnitPresenter);
                return Json(_gen_UserUnitPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddGen_UserUnit
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddGen_UserUnit(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_UserUnit/AddGen_UserUnit", new gen_userunitEntity());
        }

        /// <summary>
        /// POST AddGen_UserUnit
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGen_UserUnit([FromBody] gen_userunitEntity request)
        {
            ModelState.Remove("userid");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_UserUnitUseCase.Save(new Gen_UserUnitRequest(request), _gen_UserUnitPresenter);
            return _gen_UserUnitPresenter.ContentResult;
        }

        /// <summary>
        /// Get View EditGen_UserUnit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditGen_UserUnit([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_userunitEntity objEntity = new gen_userunitEntity();
            objEntity.serial = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serial", input).ToString());
            await _gen_UserUnitUseCase.GetSingle(new Gen_UserUnitRequest(objEntity), _gen_UserUnitPresenter);
            objEntity = _gen_UserUnitPresenter.Result as gen_userunitEntity;
            
            gen_unitEntity objgen_unitEntity = new gen_unitEntity();
			objgen_unitEntity.unitid = objEntity.unitid ;
			await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objgen_unitEntity), _gen_UnitPresenter);
			objgen_unitEntity = ((gen_unitEntity)_gen_UnitPresenter.Result);
			var datagen_unit = (new { Id = objgen_unitEntity.unitid,Text = objgen_unitEntity.unit});
			ViewBag.preloadedDatagen_unit = JsonConvert.SerializeObject(datagen_unit);

            owin_userEntity objUserEntity = new owin_userEntity();
            objUserEntity.userid = objEntity.userid ;
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objUserEntity), _owin_UserPresenter);
            objUserEntity = _owin_UserPresenter.Result as owin_userEntity;
            var dataUser = (new { Id = objUserEntity.masteruserid, Text = objUserEntity.username });
            ViewBag.preloadedDatagen_user = JsonConvert.SerializeObject(dataUser);

            return View("../General/Gen_UserUnit/EditGen_UserUnit", _gen_UserUnitPresenter.Result);
        }

        /// <summary>
        /// Post EditGen_UserUnit
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGen_UserUnit([FromBody] gen_userunitEntity request)
        {
            ModelState.Remove("userid");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_UserUnitUseCase.Update(new Gen_UserUnitRequest(request), _gen_UserUnitPresenter);
            return _gen_UserUnitPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleGen_UserUnit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleGen_UserUnit([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_userunitEntity objEntity = new gen_userunitEntity();
            objEntity.serial = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serial", input).ToString());
            await _gen_UserUnitUseCase.GetSingle(new Gen_UserUnitRequest(objEntity), _gen_UserUnitPresenter);
            objEntity = _gen_UserUnitPresenter.Result as gen_userunitEntity;
            
            gen_unitEntity objgen_unitEntity = new gen_unitEntity();
			objgen_unitEntity.unitid = objEntity.unitid ;
			await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objgen_unitEntity), _gen_UnitPresenter);
			objgen_unitEntity = ((gen_unitEntity)_gen_UnitPresenter.Result);
			var datagen_unit = (new { Id = objgen_unitEntity.unitid,Text = objgen_unitEntity.unit});
			ViewBag.preloadedDatagen_unit = JsonConvert.SerializeObject(datagen_unit);

            owin_userEntity objUserEntity = new owin_userEntity();
            objUserEntity.userid = objEntity.userid;
            await _owin_UserUseCase.GetSingle(new Owin_UserRequest(objUserEntity), _owin_UserPresenter);
            objUserEntity = _owin_UserPresenter.Result as owin_userEntity;
            var dataUser = (new { Id = objUserEntity.masteruserid, Text = objUserEntity.username });
            ViewBag.preloadedDatagen_user = JsonConvert.SerializeObject(dataUser);


            return View("../General/Gen_UserUnit/GetSingleGen_UserUnit", _gen_UserUnitPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteGen_UserUnit
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_UserUnit([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_userunitEntity objEntity = new gen_userunitEntity();
            objEntity.serial = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serial", input).ToString());
            await _gen_UserUnitUseCase.GetSingle(new Gen_UserUnitRequest(objEntity), _gen_UserUnitPresenter);
            objEntity = _gen_UserUnitPresenter.Result as gen_userunitEntity;
            
            gen_unitEntity objgen_unitEntity = new gen_unitEntity();
			objgen_unitEntity.unitid = objEntity.unitid ;
			await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objgen_unitEntity), _gen_UnitPresenter);
			objgen_unitEntity = ((gen_unitEntity)_gen_UnitPresenter.Result);
			var datagen_unit = (new { Id = objgen_unitEntity.unitid,Text = objgen_unitEntity.unitid});
			ViewBag.preloadedDatagen_unit = JsonConvert.SerializeObject(datagen_unit);



            
            return View("../General/Gen_UserUnit/DeleteGen_UserUnit", _gen_UserUnitPresenter.Result);
        }

        /// <summary>
        /// Post DeleteGen_UserUnit
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_UserUnit([FromBody] gen_userunitEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            /*				 ModelState.Remove("serial");
                  ModelState.Remove("unitid");
                  ModelState.Remove("userid");
                  ModelState.Remove("ex_nvarchar3");
 */
            ModelState.Remove("userid");
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_UserUnitUseCase.Delete(new Gen_UserUnitRequest(request), _gen_UserUnitPresenter);
            return _gen_UserUnitPresenter.ContentResult;
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetExistingDataByUserUnit([FromBody] gen_userunitEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_userunitEntity objEntity = new gen_userunitEntity();
            objEntity.unitid = request.unitid;
            objEntity.userid = request.userid;

            await _gen_UserUnitUseCase.GetSingle(new Gen_UserUnitRequest(objEntity), _gen_UserUnitPresenter);
            objEntity = _gen_UserUnitPresenter.Result as gen_userunitEntity;

            return _gen_UserUnitPresenter.ContentResult;
        }


    }
}
