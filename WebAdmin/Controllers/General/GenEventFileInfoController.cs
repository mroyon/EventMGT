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
    /// Gen_EventFileInfoController
    /// </summary>
      [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Gen_EventFileInfoController : BaseController
    {
        private readonly IGen_EventFileInfoUseCase _gen_EventFileInfoUseCase;
        private readonly Gen_EventFileInfoPresenter _gen_EventFileInfoPresenter;
        private readonly ICacheProvider _cacheProvider;


        private readonly IGen_EventInfoUseCase _gen_EventInfoUseCase;
		private readonly Gen_EventInfoPresenter _gen_EventInfoPresenter;

        

        private readonly ILogger<Gen_EventFileInfoController> _logger;
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
        /// Gen_EventFileInfoController
        /// </summary>
        /// <param name="gen_EventFileInfoUseCase"></param>
        /// <param name="gen_EventFileInfoPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
       /// <param name="gen_EventInfoUseCase"></param>
/// <param name="gen_EventInfoPresenter"></param>

        public Gen_EventFileInfoController(
            IGen_EventFileInfoUseCase gen_EventFileInfoUseCase,
            Gen_EventFileInfoPresenter gen_EventFileInfoPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            ,ICacheProvider cacheProvider
            
             , IGen_EventInfoUseCase gen_EventInfoUseCase 
			,  Gen_EventInfoPresenter gen_EventInfoPresenter

            )
        {
            _gen_EventFileInfoUseCase = gen_EventFileInfoUseCase;
            _gen_EventFileInfoPresenter = gen_EventFileInfoPresenter;
            _logger = loggerFactory.CreateLogger<Gen_EventFileInfoController>();
            _schemeProvider = schemeProvider;
            
            
             _gen_EventInfoUseCase = gen_EventInfoUseCase;
			_gen_EventInfoPresenter = gen_EventInfoPresenter;

             
             
            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;
            
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// LandingGen_EventFileInfo
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingGen_EventFileInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_EventFileInfo/LandingGen_EventFileInfo", new gen_eventfileinfoEntity());
        }

        /// <summary>
        /// ListGen_EventFileInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListGen_EventFileInfo(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                gen_eventfileinfoEntity objrequest = new gen_eventfileinfoEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Gen_EventFileInfo";
                await _gen_EventFileInfoUseCase.GetListView(new Gen_EventFileInfoRequest(objrequest), _gen_EventFileInfoPresenter);
                return Json(_gen_EventFileInfoPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddGen_EventFileInfo
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddGen_EventFileInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_EventFileInfo/AddGen_EventFileInfo", new gen_eventfileinfoEntity());
        }

        /// <summary>
        /// POST AddGen_EventFileInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGen_EventFileInfo([FromBody] gen_eventfileinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_EventFileInfoUseCase.Save(new Gen_EventFileInfoRequest(request), _gen_EventFileInfoPresenter);
            return _gen_EventFileInfoPresenter.ContentResult;
        }

        /// <summary>
        /// Get View EditGen_EventFileInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditGen_EventFileInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventfileinfoEntity objEntity = new gen_eventfileinfoEntity();
            objEntity.eventfileid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventfileid", input).ToString());
            await _gen_EventFileInfoUseCase.GetSingle(new Gen_EventFileInfoRequest(objEntity), _gen_EventFileInfoPresenter);
            objEntity = _gen_EventFileInfoPresenter.Result as gen_eventfileinfoEntity;
            
            
            gen_eventinfoEntity objgen_eventinfoEntity = new gen_eventinfoEntity();
			objgen_eventinfoEntity.eventid = objEntity.eventid ;
			await _gen_EventInfoUseCase.GetSingle(new Gen_EventInfoRequest(objgen_eventinfoEntity), _gen_EventInfoPresenter);
			objgen_eventinfoEntity = ((gen_eventinfoEntity)_gen_EventInfoPresenter.Result);
			var datagen_eventinfo = (new { Id = objgen_eventinfoEntity.eventid,Text = objgen_eventinfoEntity.eventid});
			ViewBag.preloadedDatagen_eventinfo = JsonConvert.SerializeObject(datagen_eventinfo);







            
            return View("../General/Gen_EventFileInfo/EditGen_EventFileInfo", _gen_EventFileInfoPresenter.Result);
        }

        /// <summary>
        /// Post EditGen_EventFileInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGen_EventFileInfo([FromBody] gen_eventfileinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_EventFileInfoUseCase.Update(new Gen_EventFileInfoRequest(request), _gen_EventFileInfoPresenter);
            return _gen_EventFileInfoPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleGen_EventFileInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleGen_EventFileInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventfileinfoEntity objEntity = new gen_eventfileinfoEntity();
            objEntity.eventfileid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventfileid", input).ToString());
            await _gen_EventFileInfoUseCase.GetSingle(new Gen_EventFileInfoRequest(objEntity), _gen_EventFileInfoPresenter);
            objEntity = _gen_EventFileInfoPresenter.Result as gen_eventfileinfoEntity;
            
            gen_eventinfoEntity objgen_eventinfoEntity = new gen_eventinfoEntity();
			objgen_eventinfoEntity.eventid = objEntity.eventid ;
			await _gen_EventInfoUseCase.GetSingle(new Gen_EventInfoRequest(objgen_eventinfoEntity), _gen_EventInfoPresenter);
			objgen_eventinfoEntity = ((gen_eventinfoEntity)_gen_EventInfoPresenter.Result);
			var datagen_eventinfo = (new { Id = objgen_eventinfoEntity.eventid,Text = objgen_eventinfoEntity.eventid});
			ViewBag.preloadedDatagen_eventinfo = JsonConvert.SerializeObject(datagen_eventinfo);



            
            return View("../General/Gen_EventFileInfo/GetSingleGen_EventFileInfo", _gen_EventFileInfoPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteGen_EventFileInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_EventFileInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventfileinfoEntity objEntity = new gen_eventfileinfoEntity();
            objEntity.eventfileid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventfileid", input).ToString());
            await _gen_EventFileInfoUseCase.GetSingle(new Gen_EventFileInfoRequest(objEntity), _gen_EventFileInfoPresenter);
            objEntity = _gen_EventFileInfoPresenter.Result as gen_eventfileinfoEntity;
            
            gen_eventinfoEntity objgen_eventinfoEntity = new gen_eventinfoEntity();
			objgen_eventinfoEntity.eventid = objEntity.eventid ;
			await _gen_EventInfoUseCase.GetSingle(new Gen_EventInfoRequest(objgen_eventinfoEntity), _gen_EventInfoPresenter);
			objgen_eventinfoEntity = ((gen_eventinfoEntity)_gen_EventInfoPresenter.Result);
			var datagen_eventinfo = (new { Id = objgen_eventinfoEntity.eventid,Text = objgen_eventinfoEntity.eventid});
			ViewBag.preloadedDatagen_eventinfo = JsonConvert.SerializeObject(datagen_eventinfo);



            
            return View("../General/Gen_EventFileInfo/DeleteGen_EventFileInfo", _gen_EventFileInfoPresenter.Result);
        }

        /// <summary>
        /// Post DeleteGen_EventFileInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_EventFileInfo([FromBody] gen_eventfileinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
           /*				 ModelState.Remove("eventfileid");
				 ModelState.Remove("eventid");
				 ModelState.Remove("filename");
				 ModelState.Remove("filetype");
				 ModelState.Remove("extension");
				 ModelState.Remove("filesize");
				 ModelState.Remove("filetitle");
				 ModelState.Remove("iscoverphoto");
				 ModelState.Remove("filedescription");
				 ModelState.Remove("comment");
				 ModelState.Remove("ex_nvarchar3");
*/
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_EventFileInfoUseCase.Delete(new Gen_EventFileInfoRequest(request), _gen_EventFileInfoPresenter);
            return _gen_EventFileInfoPresenter.ContentResult;
        }
        
      
        
        
        
    }
}
