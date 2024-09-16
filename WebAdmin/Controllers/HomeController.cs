using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using CLL.Localization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Web.Core.Frame.CustomIdentityManagers;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.Presenters;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using WebAdmin.Models;
using WebAdmin.Providers;
using WebAdmin.SignalRServices;
namespace WebAdmin.Controllers
{
    /// <summary>
    /// HomeController
    /// </summary>
    [Authorize(Policy = "defaultpolicy")]
    [AutoValidateAntiforgeryToken]
    public class HomeController : BaseController
    {
        private readonly IHomeUseCase _homeUseCase;
        private readonly HomePresenter _homePresenter;
        private readonly ICacheProvider _cacheProvider;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationUserManager<owin_userEntity> _userManager;
        private readonly ApplicationSignInManager<owin_userEntity> _signInManager;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IHubContext<HubUserContext> _hubuserContext;

        /// <summary>
        /// HomeController
        /// </summary>
        /// <param name="homeUseCase"></param>
        /// <param name="homePresenter"></param>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
        public HomeController(
            IHomeUseCase homeUseCase,
            HomePresenter homePresenter,

            ApplicationUserManager<owin_userEntity> userManager,
            ApplicationSignInManager<owin_userEntity> signInManager,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider,
            IHubContext<HubUserContext> hubuserContext,
            ICacheProvider cacheProvider
            )
        {
            _homeUseCase = homeUseCase;
            _homePresenter = homePresenter;

            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<HomeController>();
            _schemeProvider = schemeProvider;

            _hubuserContext = hubuserContext;

            _cacheProvider = cacheProvider;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }


        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            try
            {
                owin_userEntity objrequest = new owin_userEntity();
                objrequest.userid = new Guid(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);
                await _homeUseCase.LoadMenuByUserID(new HomeRequest(objrequest), _homePresenter);
                var menus = _homePresenter.jsonString;
                HttpContext.Session.SetRedis("menuitem", menus);

                //var result = ((IEnumerable)menus).Cast<object>().ToList();
                //session
                //var str = HttpContext.Session.GetRedis<string>("menuitem");
                //session
                //HttpContext.Session.SetRedis("Test2", menus, HttpContext.User.Identity.Name);
                //var str2 = HttpContext.Session.GetRedis<JsonContentResult>("Test2", HttpContext.User.Identity.Name);
                //cache
                //await _cacheProvider.Set<object>("Test", menus);
                //var str3 = await _cacheProvider.Get<object>("Test");


            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new Exception("first exception");
            return View();
        }

        [Authorize(Policy = "KAFSecurityPolicy")]
        /// <summary>
        /// SetLanguage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetLanguage([FromBody] LanguageSettings request)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(request.culture, request.culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), Secure = true, SameSite = SameSiteMode.Strict }
            );
            return Json(new { status = "ss", title = "ss", redirectUrl = "", responsetext = "ddd" });
        }

        /// <summary>
        /// Privacy
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Gettransferdata(string UserId)
        {
            var timerManager = new TimerManager(() => _hubuserContext.Clients.All.SendAsync("transferdata", GetData(UserId)));
            return Ok(new { Message = "Request Completed" });
        }

        /// <summary>
        /// GetData
        /// </summary>
        /// <returns></returns>
        public List<HubUserContextEntity> GetData(string UserId)
        {
            var r = new Random();
            return new List<HubUserContextEntity>()
        {
           new HubUserContextEntity { UserId = UserId, UserEmail = "Data1",  ConnectionId = "ConnectionId1" },
           new HubUserContextEntity { UserId = UserId, UserEmail = "Data2",  ConnectionId = "ConnectionId2" },
           new HubUserContextEntity { UserId = UserId, UserEmail = "Data3",  ConnectionId = "ConnectionId3" },
           new HubUserContextEntity { UserId = UserId, UserEmail = "Data4",  ConnectionId = "ConnectionId4" }
        };
        }
    }
}
