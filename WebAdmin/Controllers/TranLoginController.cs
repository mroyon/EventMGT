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
    /// Tran_LoginController
    /// </summary>
    [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Tran_LoginController : BaseController
    {
        private readonly ITran_LoginUseCase _tran_LoginUseCase;
        private readonly Tran_LoginPresenter _tran_LoginPresenter;
        private readonly ICacheProvider _cacheProvider;
        private readonly ILogger<Tran_LoginController> _logger;
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
        /// Tran_LoginController
        /// </summary>
        /// <param name="tran_LoginUseCase"></param>
        /// <param name="tran_LoginPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
       
        public Tran_LoginController(
            ITran_LoginUseCase tran_LoginUseCase,
            Tran_LoginPresenter tran_LoginPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            ,ICacheProvider cacheProvider
            
             
            )
        {
            _tran_LoginUseCase = tran_LoginUseCase;
            _tran_LoginPresenter = tran_LoginPresenter;
            _logger = loggerFactory.CreateLogger<Tran_LoginController>();
            _schemeProvider = schemeProvider;
             
            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;
            
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

        /// <summary>
        /// LandingTran_Login
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingTran_Login(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Tran_Login/LandingTran_Login", new tran_loginEntity());
        }

        /// <summary>
        /// ListTran_Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListTran_Login(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                tran_loginEntity objrequest = new tran_loginEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Tran_Login";
                await _tran_LoginUseCase.GetListView(new Tran_LoginRequest(objrequest), _tran_LoginPresenter);
                return Json(_tran_LoginPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddTran_Login
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddTran_Login(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Tran_Login/AddTran_Login", new tran_loginEntity());
        }

        /// <summary>
        /// POST AddTran_Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTran_Login([FromBody] tran_loginEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _tran_LoginUseCase.Save(new Tran_LoginRequest(request), _tran_LoginPresenter);
            return _tran_LoginPresenter.ContentResult;
        }

        /// <summary>
        /// Get View EditTran_Login
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditTran_Login([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            tran_loginEntity objEntity = new tran_loginEntity();
            objEntity.serialloginid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serialloginid", input).ToString());
            await _tran_LoginUseCase.GetSingle(new Tran_LoginRequest(objEntity), _tran_LoginPresenter);
            objEntity = _tran_LoginPresenter.Result as tran_loginEntity;
            
            
            
            
            return View("../General/Tran_Login/EditTran_Login", _tran_LoginPresenter.Result);
        }

        /// <summary>
        /// Post EditTran_Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTran_Login([FromBody] tran_loginEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _tran_LoginUseCase.Update(new Tran_LoginRequest(request), _tran_LoginPresenter);
            return _tran_LoginPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleTran_Login
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleTran_Login([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            tran_loginEntity objEntity = new tran_loginEntity();
            objEntity.serialloginid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serialloginid", input).ToString());
            await _tran_LoginUseCase.GetSingle(new Tran_LoginRequest(objEntity), _tran_LoginPresenter);
            objEntity = _tran_LoginPresenter.Result as tran_loginEntity;
            
            
            
            return View("../General/Tran_Login/GetSingleTran_Login", _tran_LoginPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteTran_Login
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteTran_Login([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            tran_loginEntity objEntity = new tran_loginEntity();
            objEntity.serialloginid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("serialloginid", input).ToString());
            await _tran_LoginUseCase.GetSingle(new Tran_LoginRequest(objEntity), _tran_LoginPresenter);
            objEntity = _tran_LoginPresenter.Result as tran_loginEntity;
            
            
            
            return View("../General/Tran_Login/DeleteTran_Login", _tran_LoginPresenter.Result);
        }

        /// <summary>
        /// Post DeleteTran_Login
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteTran_Login([FromBody] tran_loginEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
           /*				 ModelState.Remove("serialloginid");
				 ModelState.Remove("parentserialloginid");
				 ModelState.Remove("samaccount");
				 ModelState.Remove("samemail");
				 ModelState.Remove("userid");
				 ModelState.Remove("logindate");
				 ModelState.Remove("logintoken");
				 ModelState.Remove("refreshtoken");
				 ModelState.Remove("tokenissuedate");
				 ModelState.Remove("expires");
				 ModelState.Remove("remarks");
*/
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _tran_LoginUseCase.Delete(new Tran_LoginRequest(request), _tran_LoginPresenter);
            return _tran_LoginPresenter.ContentResult;
        }
        
        
        
        
    }
}
