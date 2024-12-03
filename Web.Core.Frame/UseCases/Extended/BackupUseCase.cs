using CLL.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.Interfaces.Services;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.Dto;
using AppConfig.HelperClasses;
using Web.Core.Frame.Helpers;
using System.Security.Claims;
using static AppConfig.HelperClasses.applicationEnamNConstants;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces.UseCases.Extended.IUserCase;

namespace Web.Core.Frame.UseCases
{
    public sealed partial class BackupUseCase : IBackupUseCase
    {
        private readonly IDatabaseBackupService _databaseBackupService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IJwtFactory _jwtFactory;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly ILogger<BackupUseCase> _logger;
        public Error _errors { get; set; }

        public BackupUseCase(
            IDatabaseBackupService databaseBackupService,
            IHttpContextAccessor contextAccessor,
            IJwtFactory jwtFactory,
            IStringLocalizerFactory factory,
            ILoggerFactory loggerFactory)
        {
            _contextAccessor = contextAccessor;
            _jwtFactory = jwtFactory;
            _logger = loggerFactory.CreateLogger<BackupUseCase>();

            _databaseBackupService = databaseBackupService;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public Task<bool> Handle(BackupRequest message, IOutputPort<BackupResponse> outputPort)
        {
            throw new Exception("Not Implemented");
        }

        public async Task<bool> BackupDatabase(BackupRequest message, ICRUDRequestHandler<BackupResponse> outputPort)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(message));
            try
            {
                await _databaseBackupService.BackupDatabaseAsync(message.Objbackup.filepath);
                //return Ok("Database backup completed successfully.");

                //i = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                //    .AddWithFiles(message.Objgen_eventinfo, cancellationToken);

                outputPort.GetListView(new BackupResponse(new AjaxResponse("200", _sharedLocalizer["Database backup completed successfully."].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                BackupResponse objResponse = new BackupResponse(false, _sharedLocalizer["DATA_SAVE_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Save(objResponse);
                return true;
            }
        }
    }
}