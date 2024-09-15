using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using System.Linq;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using Web.Core.Frame.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
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
    /// HubCivilUserContext
    /// </summary>
     [AllowAnonymous]
    public class HubCivilUserContext : Hub<ISignalRCiviClientInterface>
    {

        private readonly IStringCompression _stringCompression;
        private readonly ILogger<HubCivilUserContext> _logger;
        private readonly IConfiguration _config;
        private readonly IHubContext<HubCivilUserContext> _hubContext;
        private readonly IConfiguration _configuration;

        private readonly ISignalROnlineCivilUserRepository _signalROnlineCivilUserRepository;

        string code = string.Empty;
        string codecivilid = string.Empty;

        /// <summary>
        /// HubCivilUserContext
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="stringCompression"></param>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="configuration"></param>
        /// <param name="signalRCivilUserDataService"></param>
        public HubCivilUserContext(
            IHubContext<HubCivilUserContext> hubContext,
            IStringCompression stringCompression,
            IConfiguration config,
            ILoggerFactory loggerFactory,

            IConfiguration configuration,

            ISignalRCivilUserDataService signalRCivilUserDataService
            )
        {
            _stringCompression = stringCompression;
            _config = config;
            _logger = loggerFactory.CreateLogger<HubCivilUserContext>();
            _hubContext = hubContext;
            _signalROnlineCivilUserRepository = signalRCivilUserDataService.MongoSignalRCivilUserRepository;
            _configuration = configuration;

        }

        /// <summary>
        /// OnConnectedAsync
        /// </summary>
        /// <returns></returns>
        public async override Task OnConnectedAsync()
        {
            code = Context.GetHttpContext().Request.Query["code"];
            codecivilid = Context.GetHttpContext().Request.Query["civilid"];
            await base.OnConnectedAsync();
            if (!code.Contains("_SIGRES_")) // caller not from application
            {
                await _signalROnlineCivilUserRepository.UpdateOnlineUser(Context.GetHttpContext(), Context.ConnectionId, code, codecivilid);
                HubCivilUserContextEntity User = await _signalROnlineCivilUserRepository.FindByConnectionIDOrCode(Context.ConnectionId, code, codecivilid);
                await Clients.Client(Context.ConnectionId).ParticipantConnectedSuccessfullyCivil(User.ConnectionId, User.TemIdentifierCode);
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
            codecivilid = Context.GetHttpContext().Request.Query["civilid"];
            var value = await Task.FromResult(0);//adding dump code to follow the template of Hub > OnDisconnectedAsync
            await base.OnDisconnectedAsync(exception);
            if (!code.Contains("_SIGRES_")) // caller not from application
            {
                var user = await _signalROnlineCivilUserRepository.RemoveOnlineUser(Context.GetHttpContext(), Context.ConnectionId, code, codecivilid);
                _logger.LogInformation("User: " + user.ConnectionId + " logged removed. ");
            }
        }


        /// <summary>
        /// UpdateExistingConnectionData
        /// </summary>
        /// <param name="KeyParam"></param>
        /// <param name="OldcCnnectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        public async Task UpdateExistingConnectionData(string KeyParam, string OldcCnnectionid, string code, string codecivilid)
        {
            AppConfig.EncryptionHandler.EncryptionHelper objEnc = new AppConfig.EncryptionHandler.EncryptionHelper();
            var ConnectionId = Context.ConnectionId;
            var strKeyParam = objEnc.decryptSimple(KeyParam);
            PaciKeyParamsValuesEntity objKeyParam = JsonConvert.DeserializeObject<PaciKeyParamsValuesEntity>(strKeyParam);
            await _signalROnlineCivilUserRepository.UpdateOnlineUserAfterCivil(Context.GetHttpContext(), Context.ConnectionId, code, codecivilid, objKeyParam);
            await Clients.Client(Context.ConnectionId).PostMsgToClientForConnectionIDUpdated(codecivilid, KeyParam, Context.ConnectionId, OldcCnnectionid);

        }



        /// <summary>
        /// PostAuthenticationProcessCall
        /// </summary>
        /// <param name="civilid"></param>
        /// <param name="keyparam"></param>
        /// <param name="ResultDetails"></param>
        /// <param name="userdata"></param>
        /// <param name="pacipersonaldata"></param>
        /// <returns></returns>
        public async Task PostAuthenticationProcessCallCivil(string civilid, string keyparam, string resultdetails, string personaldata, string pacipersonaldata)
        {
            AppConfig.EncryptionHandler.EncryptionHelper objEnc = new AppConfig.EncryptionHandler.EncryptionHelper();
            PaciKeyParamsValuesEntity objKeyParam = JsonConvert.DeserializeObject<PaciKeyParamsValuesEntity>(objEnc.decryptSimple(keyparam));

            var _resultdetails = resultdetails;// objEnc.decryptSimple(resultdetails);
            var _personaldata = personaldata;//objEnc.decryptSimple(personaldata);
            var _pacipersonaldata = pacipersonaldata;// objEnc.decryptSimple(pacipersonaldata);

            code = objKeyParam.WebSessionID;
            codecivilid = objKeyParam.CivilID;
            var user2 = await _signalROnlineCivilUserRepository.FindByConnectionIDOrCode(Context.ConnectionId, code, codecivilid);
            await _signalROnlineCivilUserRepository.RemoveOnlineUser(Context.GetHttpContext(), user2.ConnectionId, code, codecivilid);
            await Clients.Client(user2.ConnectionId).PostAuthenticationProcessCallCivil(civilid, keyparam, _resultdetails, _personaldata, _pacipersonaldata);
        }


        /// <summary>
        /// PostUnAuthorizedProcessCall
        /// </summary>
        /// <param name="keyparam"></param>
        /// <param name="civilid"></param>
        /// <returns></returns>
        public async Task PostUnAuthorizedProcessCall(string keyparam, string civilid)
        {
            AppConfig.EncryptionHandler.EncryptionHelper objEnc = new AppConfig.EncryptionHandler.EncryptionHelper();
            PaciKeyParamsValuesEntity objKeyParam = JsonConvert.DeserializeObject<PaciKeyParamsValuesEntity>(objEnc.decryptSimple(keyparam));
            code = objKeyParam.WebSessionID;
            codecivilid = objKeyParam.CivilID;

            var user2 = await _signalROnlineCivilUserRepository.FindByConnectionIDOrCode(Context.ConnectionId, code, codecivilid);
            await _signalROnlineCivilUserRepository.RemoveOnlineUser(Context.GetHttpContext(), user2.ConnectionId, code, codecivilid);

            await Clients.Client(user2.ConnectionId).PostUnAuthorizedProcessCallCivil(keyparam, civilid);
        }

    }
}
