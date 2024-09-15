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

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Gen_EventCategoryController
    /// </summary>
    [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Gen_EventCategoryController : BaseController
    {
        private readonly IGen_EventCategoryUseCase _gen_EventCategoryUseCase;
        private readonly Gen_EventCategoryPresenter _gen_EventCategoryPresenter;
        private readonly ICacheProvider _cacheProvider;





        private readonly ILogger<Gen_EventCategoryController> _logger;
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
        /// Gen_EventCategoryController
        /// </summary>
        /// <param name="gen_EventCategoryUseCase"></param>
        /// <param name="gen_EventCategoryPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>

        public Gen_EventCategoryController(
            IGen_EventCategoryUseCase gen_EventCategoryUseCase,
            Gen_EventCategoryPresenter gen_EventCategoryPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            , ICacheProvider cacheProvider


            )
        {
            _gen_EventCategoryUseCase = gen_EventCategoryUseCase;
            _gen_EventCategoryPresenter = gen_EventCategoryPresenter;
            _logger = loggerFactory.CreateLogger<Gen_EventCategoryController>();
            _schemeProvider = schemeProvider;





            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingGen_EventCategory
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingGen_EventCategory(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_EventCategory/LandingGen_EventCategory", new gen_eventcategoryEntity());
        }

        /// <summary>
        /// ListGen_EventCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListGen_EventCategory(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                gen_eventcategoryEntity objrequest = new gen_eventcategoryEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Gen_EventCategory";
                await _gen_EventCategoryUseCase.GetListView(new Gen_EventCategoryRequest(objrequest), _gen_EventCategoryPresenter);
                return Json(_gen_EventCategoryPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddGen_EventCategory
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddGen_EventCategory(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_EventCategory/AddGen_EventCategory", new gen_eventcategoryEntity());
        }

        /// <summary>
        /// POST AddGen_EventCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGen_EventCategory([FromBody] gen_eventcategoryEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_EventCategoryUseCase.Save(new Gen_EventCategoryRequest(request), _gen_EventCategoryPresenter);
            return _gen_EventCategoryPresenter.ContentResult;
        }

        /// <summary>
        /// Get View EditGen_EventCategory
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditGen_EventCategory([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventcategoryEntity objEntity = new gen_eventcategoryEntity();
            objEntity.eventcategoryid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventcategoryid", input).ToString());
            await _gen_EventCategoryUseCase.GetSingle(new Gen_EventCategoryRequest(objEntity), _gen_EventCategoryPresenter);
            objEntity = _gen_EventCategoryPresenter.Result as gen_eventcategoryEntity;




            return View("../General/Gen_EventCategory/EditGen_EventCategory", _gen_EventCategoryPresenter.Result);
        }

        /// <summary>
        /// Post EditGen_EventCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGen_EventCategory([FromBody] gen_eventcategoryEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_EventCategoryUseCase.Update(new Gen_EventCategoryRequest(request), _gen_EventCategoryPresenter);
            return _gen_EventCategoryPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleGen_EventCategory
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleGen_EventCategory([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventcategoryEntity objEntity = new gen_eventcategoryEntity();
            objEntity.eventcategoryid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventcategoryid", input).ToString());
            await _gen_EventCategoryUseCase.GetSingle(new Gen_EventCategoryRequest(objEntity), _gen_EventCategoryPresenter);
            objEntity = _gen_EventCategoryPresenter.Result as gen_eventcategoryEntity;



            return View("../General/Gen_EventCategory/GetSingleGen_EventCategory", _gen_EventCategoryPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteGen_EventCategory
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_EventCategory([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventcategoryEntity objEntity = new gen_eventcategoryEntity();
            objEntity.eventcategoryid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventcategoryid", input).ToString());
            await _gen_EventCategoryUseCase.GetSingle(new Gen_EventCategoryRequest(objEntity), _gen_EventCategoryPresenter);
            objEntity = _gen_EventCategoryPresenter.Result as gen_eventcategoryEntity;



            return View("../General/Gen_EventCategory/DeleteGen_EventCategory", _gen_EventCategoryPresenter.Result);
        }

        /// <summary>
        /// Post DeleteGen_EventCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_EventCategory([FromBody] gen_eventcategoryEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            /*				 ModelState.Remove("eventcategoryid");
                  ModelState.Remove("eventcategory");
                  ModelState.Remove("description");
                  ModelState.Remove("ex_nvarchar3");
 */
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_EventCategoryUseCase.Delete(new Gen_EventCategoryRequest(request), _gen_EventCategoryPresenter);
            return _gen_EventCategoryPresenter.ContentResult;
        }



        /// <summary>
        /// GetDataForDropDown Gen_EventCategory
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetDataForDropDowndGen_EventCategory([FromBody] S2Parameters request)
        {
            try
            {
                gen_eventcategoryEntity objrequest = new gen_eventcategoryEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.s2PageNum.GetValueOrDefault(1);
                objrequest.PageSize = request.s2PageSize.GetValueOrDefault(10);
                objrequest.SortExpression = " eventcategory asc ";
                objrequest.strCommonSerachParam = request.s2SearchTerm;
                objrequest.ControllerName = "Gen_EventCategory";
                await _gen_EventCategoryUseCase.GetDataForDropDown(new Gen_EventCategoryRequest(objrequest), _gen_EventCategoryPresenter);
                return Json(_gen_EventCategoryPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       


    }
}
