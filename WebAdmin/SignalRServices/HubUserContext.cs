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

namespace WebAdmin.SignalRServices
{
    /// <summary>
    /// HubUserContext
    /// </summary>
    [Authorize]
    public class HubUserContext : Hub<ISignalRClientInterface>
    {

        private readonly IStringCompression _stringCompression;
        private readonly ILogger<HubUserContext> _logger;
        private readonly IConfiguration _config;
        private readonly IUserProfileParserService _iUserProfileParserService;
        private readonly IHubContext<HubUserContext> _hubContext;
        private readonly IConfiguration _configuration;

        private readonly ISignalROnlineUserRepository _signalROnlineUserRepository;

        /// <summary>
        /// HubUserContext
        /// </summary>
        /// <param name="hubContext"></param>
        /// <param name="iUserProfileParserService"></param>
        /// <param name="stringCompression"></param>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="hr_CorsApiServicesUseCase"></param>
        /// <param name="hr_CorsApiServicesPresenter"></param>
        /// <param name="configuration"></param>
        /// <param name="signalRUserDataService"></param>

        public HubUserContext(
            IHubContext<HubUserContext> hubContext,
            IUserProfileParserService iUserProfileParserService,
            IStringCompression stringCompression,
            IConfiguration config,
            ILoggerFactory loggerFactory,
            
            IConfiguration configuration,

            ISignalRUserDataService signalRUserDataService
            )
        {
            _stringCompression = stringCompression;
            _config = config;
            _logger = loggerFactory.CreateLogger<HubUserContext>();
            _iUserProfileParserService = iUserProfileParserService;
            _hubContext = hubContext;
            _signalROnlineUserRepository = signalRUserDataService.MongoSignalRUserRepository;
            _configuration = configuration;

        }

        /// <summary>
        /// OnConnectedAsync
        /// </summary>
        /// <returns></returns>
        public async override Task OnConnectedAsync()
        {
            await _signalROnlineUserRepository.UpdateOnlineUser(Context.GetHttpContext(), Context.ConnectionId);
            await base.OnConnectedAsync();
            HubUserContextEntity User = _iUserProfileParserService.GetPrpfileFromClaim(Context.ConnectionId, Context.GetHttpContext());
            await Clients.Client(Context.ConnectionId).ParticipantConnectedSuccessfully(Context.ConnectionId, User.UserEmail);
        }


        /// <summary>
        /// OnDisconnectedAsync
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        //Called when a connection with the hub is terminated.
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            
            var value = await Task.FromResult(0);//adding dump code to follow the template of Hub > OnDisconnectedAsync
            await base.OnDisconnectedAsync(exception);
            var user = await _signalROnlineUserRepository.RemoveOnlineUser(Context.GetHttpContext(), Context.ConnectionId);
            _logger.LogInformation("User: " + user.UserEmail + " logged removed. ");


            List<HubUserContextEntity> userlist = new List<HubUserContextEntity>();
            userlist = await _signalROnlineUserRepository.GetOnlineUserListFromDB();
            string userlistJson = JsonConvert.SerializeObject(userlist);


            await Clients.Others.DeletedConnectedParticipant(userlistJson);
        }


        /// <summary>
        /// GetEnlistedClientsList
        /// </summary>
        /// <returns></returns>
        public async Task GetEnlistedClientsList()
        {
            List<HubUserContextEntity> userlist = new List<HubUserContextEntity>();
            await _signalROnlineUserRepository.AddeOnlineUser(Context.GetHttpContext(), Context.ConnectionId);
            userlist = await _signalROnlineUserRepository.GetOnlineUserListFromDB();

            string userlistJson = JsonConvert.SerializeObject(userlist);

            foreach (var singleconnection in userlist)
            {
                await Clients.Client(singleconnection.ConnectionId).CompleteConnectionParticipantList(userlistJson);
            }
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toemail"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task SendClientSpecificMsg(string toemail, string msg)
        {
            List<HubUserContextEntity> onlineuserlist = new List<HubUserContextEntity>();
            onlineuserlist = await _signalROnlineUserRepository.GetOnlineUserListFromDB();

            HubUserContextEntity User = _iUserProfileParserService.GetPrpfileFromClaim(Context.ConnectionId, Context.GetHttpContext());
            var connectionid = onlineuserlist.Where(p => p.UserEmail == toemail.Trim()).FirstOrDefault().ConnectionId;
            await Clients.Client(connectionid).SendMsgtoSpecificClient(msg, User.UserEmail);
        }




     

    }
}
