using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using System.Linq;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using Web.Core.Frame.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebAdmin.IntraServices;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.Net;
using BDO.DataAccessObjects.ExtendedEntities;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Web.Core.Frame.CustomStores;
using System.Net.Mail;
using Web.Core.Frame.Presenters;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.Interfaces.UseCases;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using System.Configuration;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using MongoDB.Driver.Core.Connections;
using static IdentityServer4.Models.IdentityResources;
using ClosedXML;
using ClosedXML.Excel;
using BDO.DataAccessObjects.ApiModels;

namespace WebAdmin.SignalRServices
{
    /// <summary>
    /// HubQRUserContext
    /// </summary>
    [AllowAnonymous]
    public class HubQRUserContext : Hub<ISignalRQRClientInterface>
    {

        private readonly IStringCompression _stringCompression;
        private readonly ILogger<HubQRUserContext> _logger;
        private readonly IConfiguration _config;
        private readonly IHubContext<HubQRUserContext> _hubContext;
        private readonly IConfiguration _configuration;

        private readonly ISignalROnlineQRUserRepository _signalROnlineQRUserRepository;

        string code = string.Empty;

        /*
            NOTE:
                1. _SIGRES_ means that the connection has been invoke from paci api. so we do not need to store the connection info
        */

        /// <summary>
        /// HubQRUserContext
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="stringCompression"></param>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="signalRQRUserDataService"></param>
        public HubQRUserContext(
            IHubContext<HubQRUserContext> hubContext,
            IStringCompression stringCompression,
            IConfiguration config,
            ILoggerFactory loggerFactory,

            IConfiguration configuration,

            ISignalRQRUserDataService signalRQRUserDataService
            )
        {
            _stringCompression = stringCompression;
            _config = config;
            _logger = loggerFactory.CreateLogger<HubQRUserContext>();
            _hubContext = hubContext;
            _signalROnlineQRUserRepository = signalRQRUserDataService.MongoSignalRQRUserRepository;
            _configuration = configuration;

        }

        /// <summary>
        /// OnConnectedAsync
        /// </summary>
        /// <returns></returns>
        public async override Task OnConnectedAsync()
        {
            code = Context.GetHttpContext().Request.Query["code"];
            await base.OnConnectedAsync();
            if (!code.Contains("_SIGRES_")) // caller not from application
            {
                await _signalROnlineQRUserRepository.UpdateOnlineUser(Context.GetHttpContext(), Context.ConnectionId, code);
                HubQRUserContextEntity User = await _signalROnlineQRUserRepository.FindByConnectionIDOrCode(Context.ConnectionId, code);
                await Clients.Client(Context.ConnectionId).ParticipantConnectedSuccessfullyQR(User.ConnectionId, User.TemIdentifierCode);
            }
        }


        /// <summary>
        /// OnDisconnectedAsync
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        //Called when a connection with the hub is terminated.
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            code = Context.GetHttpContext().Request.Query["code"];
            var value = await Task.FromResult(0);//adding dump code to follow the template of Hub > OnDisconnectedAsync
            await base.OnDisconnectedAsync(exception);
            if (!code.Contains("_SIGRES_")) // caller not from application
            {
                var user = await _signalROnlineQRUserRepository.RemoveOnlineUser(Context.GetHttpContext(), Context.ConnectionId, code);
                _logger.LogInformation("User: " + user.ConnectionId + " logged removed. ");
            }
        }


        /// <summary>
        /// UpdateExistingConnectionData
        /// </summary>
        /// <param name="KeyParam"></param>
        /// <param name="OldcCnnectionid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task UpdateExistingConnectionData(string KeyParam, string OldcCnnectionid, string code)
        {
            AppConfig.EncryptionHandler.EncryptionHelper objEnc = new AppConfig.EncryptionHandler.EncryptionHelper();
            var ConnectionId = Context.ConnectionId;
            var strKeyParam = objEnc.decryptSimple(KeyParam);
            PaciKeyParamsValuesEntity objKeyParam = JsonConvert.DeserializeObject<PaciKeyParamsValuesEntity>(strKeyParam);
            await _signalROnlineQRUserRepository.UpdateOnlineUserAfterQR(Context.GetHttpContext(), Context.ConnectionId, code, objKeyParam);
            await Clients.Client(Context.ConnectionId).PostMsgToClientForConnectionIDUpdated(KeyParam, Context.ConnectionId, OldcCnnectionid);

        }



        /// <summary>
        /// PostAuthenticationProcessCallQR
        /// </summary>
        /// <param name="civilid"></param>
        /// <param name="keyparam"></param>
        /// <param name="resultdetails"></param>
        /// <param name="personaldata"></param>
        /// <param name="pacipersonaldata"></param>
        /// <returns></returns>
        public async Task PostAuthenticationProcessCallQR(string civilid, string keyparam, string resultdetails, string personaldata, string pacipersonaldata)
        {
            AppConfig.EncryptionHandler.EncryptionHelper objEnc = new AppConfig.EncryptionHandler.EncryptionHelper();
            PaciKeyParamsValuesEntity objKeyParam = JsonConvert.DeserializeObject<PaciKeyParamsValuesEntity>(objEnc.decryptSimple(keyparam));
            code = objKeyParam.WebSessionID;
            var user2 = await _signalROnlineQRUserRepository.FindByConnectionIDOrCode(Context.ConnectionId, code);
            await _signalROnlineQRUserRepository.RemoveOnlineUser(Context.GetHttpContext(), user2.ConnectionId, code);
            await Clients.Client(user2.ConnectionId).PostAuthenticationProcessCallQR(civilid, keyparam, resultdetails, personaldata, pacipersonaldata);
        }


        /// <summary>
        /// PostUnAuthorizedProcessCall
        /// </summary>
        /// <param name="keyparam"></param>
        /// <param name="civilid"></param>
        /// <returns></returns>
        public async Task PostUnAuthorizedProcessCall(string keyparam,string civilid)
        {
            AppConfig.EncryptionHandler.EncryptionHelper objEnc = new AppConfig.EncryptionHandler.EncryptionHelper();
            PaciKeyParamsValuesEntity objKeyParam = JsonConvert.DeserializeObject<PaciKeyParamsValuesEntity>(objEnc.decryptSimple(keyparam));
            code = objKeyParam.WebSessionID;

            var user2 = await _signalROnlineQRUserRepository.FindByConnectionIDOrCode(Context.ConnectionId, code);
            await _signalROnlineQRUserRepository.RemoveOnlineUser(Context.GetHttpContext(), user2.ConnectionId, code);
            
            await Clients.Client(user2.ConnectionId).PostUnAuthorizedProcessCallQR(keyparam, civilid);
        }

    }
}
