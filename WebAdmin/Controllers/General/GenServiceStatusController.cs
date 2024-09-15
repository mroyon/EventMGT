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
using Web.Core.Frame.UseCases;
using Org.BouncyCastle.Asn1.Ocsp;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Gen_ServiceStatusController
    /// </summary>
    [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Gen_ServiceStatusController : BaseController
    {
        private readonly IGen_ServiceStatusUseCase _gen_ServiceStatusUseCase;
        private readonly Gen_ServiceStatusPresenter _gen_ServiceStatusPresenter;
        private readonly ICacheProvider _cacheProvider;





        private readonly ILogger<Gen_ServiceStatusController> _logger;
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
        /// Gen_ServiceStatusController
        /// </summary>
        /// <param name="gen_ServiceStatusUseCase"></param>
        /// <param name="gen_ServiceStatusPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>

        public Gen_ServiceStatusController(
            IGen_ServiceStatusUseCase gen_ServiceStatusUseCase,
            Gen_ServiceStatusPresenter gen_ServiceStatusPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            , ICacheProvider cacheProvider


            )
        {
            _gen_ServiceStatusUseCase = gen_ServiceStatusUseCase;
            _gen_ServiceStatusPresenter = gen_ServiceStatusPresenter;
            _logger = loggerFactory.CreateLogger<Gen_ServiceStatusController>();
            _schemeProvider = schemeProvider;





            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingGen_ServiceStatus
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingGen_ServiceStatus(string returnUrl)
        {

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_ServiceStatus/LandingGen_ServiceStatus", new gen_servicestatusEntity());
        }

        /// <summary>
        /// ListGen_ServiceStatus
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListGen_ServiceStatus(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                gen_servicestatusEntity objrequest = new gen_servicestatusEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Gen_ServiceStatus";
                await _gen_ServiceStatusUseCase.GetListView(new Gen_ServiceStatusRequest(objrequest), _gen_ServiceStatusPresenter);
                return Json(_gen_ServiceStatusPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddGen_ServiceStatus
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddGen_ServiceStatus(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_ServiceStatus/AddGen_ServiceStatus", new gen_servicestatusEntity());
        }

        /// <summary>
        /// POST AddGen_ServiceStatus
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGen_ServiceStatus([FromBody] gen_servicestatusEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_ServiceStatusUseCase.Save(new Gen_ServiceStatusRequest(request), _gen_ServiceStatusPresenter);
            return _gen_ServiceStatusPresenter.ContentResult;
        }

        /// <summary>
        /// Get View EditGen_ServiceStatus
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditGen_ServiceStatus([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_servicestatusEntity objEntity = new gen_servicestatusEntity();
            objEntity.servicestatusid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("servicestatusid", input).ToString());
            await _gen_ServiceStatusUseCase.GetSingle(new Gen_ServiceStatusRequest(objEntity), _gen_ServiceStatusPresenter);
            objEntity = _gen_ServiceStatusPresenter.Result as gen_servicestatusEntity;




            return View("../General/Gen_ServiceStatus/EditGen_ServiceStatus", _gen_ServiceStatusPresenter.Result);
        }

        /// <summary>
        /// Post EditGen_ServiceStatus
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGen_ServiceStatus([FromBody] gen_servicestatusEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_ServiceStatusUseCase.Update(new Gen_ServiceStatusRequest(request), _gen_ServiceStatusPresenter);
            return _gen_ServiceStatusPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleGen_ServiceStatus
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleGen_ServiceStatus([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_servicestatusEntity objEntity = new gen_servicestatusEntity();
            objEntity.servicestatusid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("servicestatusid", input).ToString());
            await _gen_ServiceStatusUseCase.GetSingle(new Gen_ServiceStatusRequest(objEntity), _gen_ServiceStatusPresenter);
            objEntity = _gen_ServiceStatusPresenter.Result as gen_servicestatusEntity;



            return View("../General/Gen_ServiceStatus/GetSingleGen_ServiceStatus", _gen_ServiceStatusPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteGen_ServiceStatus
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_ServiceStatus([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_servicestatusEntity objEntity = new gen_servicestatusEntity();
            objEntity.servicestatusid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("servicestatusid", input).ToString());
            await _gen_ServiceStatusUseCase.GetSingle(new Gen_ServiceStatusRequest(objEntity), _gen_ServiceStatusPresenter);
            objEntity = _gen_ServiceStatusPresenter.Result as gen_servicestatusEntity;



            return View("../General/Gen_ServiceStatus/DeleteGen_ServiceStatus", _gen_ServiceStatusPresenter.Result);
        }

        /// <summary>
        /// Post DeleteGen_ServiceStatus
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_ServiceStatus([FromBody] gen_servicestatusEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            /*				 ModelState.Remove("servicestatusid");
                  ModelState.Remove("servicestatusar");
                  ModelState.Remove("servicestatusen");
                  ModelState.Remove("descriptionar");
                  ModelState.Remove("descriptionen");
                  ModelState.Remove("isactive");
 */
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_ServiceStatusUseCase.Delete(new Gen_ServiceStatusRequest(request), _gen_ServiceStatusPresenter);
            return _gen_ServiceStatusPresenter.ContentResult;
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetDataForDropDowndGen_ServiceStatus([FromBody] S2Parameters request)
        {
            try
            {
                gen_servicestatusEntity objrequest = new gen_servicestatusEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.s2PageNum.GetValueOrDefault(1);
                objrequest.PageSize = request.s2PageSize.GetValueOrDefault(10);
                objrequest.SortExpression = " servicestatusid asc ";
                objrequest.strCommonSerachParam = request.s2SearchTerm;
                objrequest.ControllerName = "Gen_ServiceStatus";
                objrequest.isactive = true;
                objrequest.isExt = request.IsMapped;
                objrequest.prntkey = string.IsNullOrEmpty(request.s2ParamParentkey) == false ? long.Parse(request.s2ParamParentkey) : null;

                await _gen_ServiceStatusUseCase.GetDataForDropDown(new Gen_ServiceStatusRequest(objrequest), _gen_ServiceStatusPresenter);
                return Json(_gen_ServiceStatusPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetAllDataForDropDowndGen_ServiceStatus()
        {
            try
            {
                gen_servicestatusEntity objrequest = new gen_servicestatusEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                //objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = 1;
                objrequest.PageSize = 500;
                objrequest.SortExpression = " servicestatusid asc ";
                //objrequest.strCommonSerachParam = request.s2SearchTerm;
                objrequest.ControllerName = "Gen_ServiceStatus";
                objrequest.isactive = true;

                await _gen_ServiceStatusUseCase.GetALLDataForDropDown(new Gen_ServiceStatusRequest(objrequest), _gen_ServiceStatusPresenter);
                return Json(_gen_ServiceStatusPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
