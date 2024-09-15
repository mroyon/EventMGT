using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web.Core.Frame.Interfaces.Services;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.Presenters;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.UseCases;
using WebAdmin.SignalRServices;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// IUserProfileParserService
    /// </summary>
    public class UserProfileParserService : IUserProfileParserService
    {

        private readonly IJwtTokenValidator _ijwttokenvalidator;
        private readonly ILogger<UserProfileParserService> _logger;
        private readonly IConfiguration _config;
        private readonly IStringCompression _stringCompression;

        

        /// <summary>
        /// UserProfileParserService
        /// </summary>
        /// <param name="config"></param>
        /// <param name="ijwttokenvalidator"></param>
        /// <param name="stringCompression"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="conf_ReceiverGroupDetUseCase"></param>
        /// <param name="conf_ReceiverGroupDetPresenter"></param>
        /// <param name="hr_CorsApiServicesUseCase"></param>
        /// <param name="hr_CorsApiServicesPresenter"></param>
        public UserProfileParserService(
            IConfiguration config,
            IJwtTokenValidator ijwttokenvalidator,
            IStringCompression stringCompression,
            ILoggerFactory loggerFactory)
        {
            _config = config;
            _stringCompression = stringCompression;
            _logger = loggerFactory.CreateLogger<UserProfileParserService>();
            _ijwttokenvalidator = ijwttokenvalidator;

        }

         
        /// <summary>
        /// GetPrpfileFromClaim
        /// </summary>
        /// <param name="connectionid"></param>
        /// <param name="httpCtx"></param>
        /// <returns></returns>
        public HubUserContextEntity GetPrpfileFromClaim(string connectionid, Microsoft.AspNetCore.Http.HttpContext httpCtx)
        {
            HubUserContextEntity objConnectedUser = new HubUserContextEntity();
            owin_userEntity objUser = new owin_userEntity();
            if (httpCtx != null)
            {
                var userClaimsList = httpCtx.User.Claims.ToList();
                if (userClaimsList != null)
                {
                    var strZipedprofile = userClaimsList.ToList().Find(c => c.Type == "profileJson")?.Value;
                    if (!string.IsNullOrEmpty(strZipedprofile))
                    {
                        var unzipprofile = _stringCompression.UnZip(strZipedprofile);
                        if (!string.IsNullOrEmpty(unzipprofile))
                        {
                            objUser = Newtonsoft.Json.JsonConvert.DeserializeObject<owin_userEntity>(unzipprofile);
                            if (objUser != null)
                            {
                                objConnectedUser.TemIdentifierCode = userClaimsList.ToList().Find(c => c.Type == "TemIdentifierCode")?.Value;
                                objConnectedUser.userProfile = objUser;
                                objConnectedUser.UserIP = objUser.BaseSecurityParam?.ipaddress;
                                objConnectedUser.UserId = objUser.userid.ToString();
                                objConnectedUser.UserName = objUser.username;
                                objConnectedUser.UserEmail = objUser.emailaddress;
                                objConnectedUser.ConnectionId = connectionid;
                                objConnectedUser.PKeyEX = objUser.pkeyex;
                                objConnectedUser.LoggedInTime = System.DateTime.Now;

                            }
                        }
                    }
                }
            }

            if (objConnectedUser.UserEmail != "")
                return objConnectedUser;
            else return null;
        }

        /// <summary>
        /// AddUpdateUserConnection
        /// </summary>
        /// <param name="objHubUserContext"></param>
        /// <param name="hubContext"></param>
        /// <returns></returns>
        public HubUserContextEntity AddUpdateUserConnection(owin_userEntity objHubUserContext, HubCallerContext hubContext)
        {
            HubUserContextEntity objNewUser = new HubUserContextEntity();
            return objNewUser;
        }

        /// <summary>
        /// RemoveUserByConnectionID
        /// </summary>
        /// <param name="connectionID"></param>
        public void RemoveUserByConnectionID(string connectionID)
        {
            string userid = string.Empty;
            //Remove the connectionId of user 

        }

        /// <summary>
        /// RemoveUserByUserID
        /// </summary>
        /// <param name="userId"></param>
        public void RemoveUserByUserID(string userId)
        {
            //Remove the connectionId of user 

        }

        /// <summary>
        /// GetUserFromConnectionsByUserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public HubUserContextEntity GetUserFromConnectionsByUserID(string userId)
        {
            HubUserContextEntity objNewUser = new HubUserContextEntity();
            return objNewUser;
        }

    }
}
