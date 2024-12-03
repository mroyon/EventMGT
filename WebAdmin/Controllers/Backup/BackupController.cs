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
using Web.Core.Frame.Interfaces.UseCases.Extended.IUserCase;
using Web.Core.Frame.UseCases;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// BackupController
    /// </summary>
    //[Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class BackupController : BaseController
    {
        private readonly IBackupUseCase _backupUseCase;
        private readonly BackupPresenter _backupPresenter;
        private readonly ILogger<BackupController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;

        /// <summary>
        /// _configuration
        /// </summary>
        public IConfiguration _configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="backupUseCase"></param>
        /// <param name="backupPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>

        public BackupController(
            IBackupUseCase backupUseCase,
            BackupPresenter backupPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory
            )
        {
            _backupUseCase = backupUseCase;
            _backupPresenter = backupPresenter;
            _logger = loggerFactory.CreateLogger<BackupController>();

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

        /// <summary>
        /// LandingBackup
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> LandingBackup(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../Backup/LandingBackup", new backupEntity());
        }

        /// <summary>
        /// SaveDatabaseBackup
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SaveDatabaseBackup([FromBody] backupEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _backupUseCase.BackupDatabase(new BackupRequest(request), _backupPresenter);
            return _backupPresenter.ContentResult;
        }
    }
}
