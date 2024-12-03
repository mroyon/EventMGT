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
    //[Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class BackupController : BaseController
    {
        private readonly IGen_EventCategoryUseCase _gen_EventCategoryUseCase;
        private readonly Gen_EventCategoryPresenter _gen_EventCategoryPresenter;
        private readonly ILogger<BackupController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;

        /// <summary>
        /// _configuration
        /// </summary>
        public IConfiguration _configuration { get; }

        /// <summary>
        /// BackupController
        /// </summary>
        /// <param name="gen_EventCategoryUseCase"></param>
        /// <param name="gen_EventCategoryPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>

        public BackupController(
            IGen_EventCategoryUseCase gen_EventCategoryUseCase,
            Gen_EventCategoryPresenter gen_EventCategoryPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory
            )
        {
            _gen_EventCategoryUseCase = gen_EventCategoryUseCase;
            _gen_EventCategoryPresenter = gen_EventCategoryPresenter;
            _logger = loggerFactory.CreateLogger<BackupController>();

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

    }
}
