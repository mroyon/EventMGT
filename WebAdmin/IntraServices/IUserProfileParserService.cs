using BDO.Core.DataAccessObjects.Models;
using CLL.LLClasses.SecurityModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.SignalRServices;
using BDO.Core.DataAccessObjects.SecurityModels;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// IUserProfileParserService
    /// </summary>
    public interface IUserProfileParserService
    {
        /// <summary>
        /// GetPrpfileFromClaim
        /// </summary>
        /// <param name="connectionid"></param>
        /// <param name="httpCtx"></param>
        /// <returns></returns>
        HubUserContextEntity GetPrpfileFromClaim(string connectionid, Microsoft.AspNetCore.Http.HttpContext httpCtx);

        /// <summary>
        /// AddUpdateUserConnection
        /// </summary>
        /// <param name="objUer"></param>
        /// <param name="hubContext"></param>
        /// <returns></returns>
        HubUserContextEntity AddUpdateUserConnection(owin_userEntity objUer, HubCallerContext hubContext);

        /// <summary>
        /// RemoveUserByConnectionID
        /// </summary>
        /// <param name="connectionID"></param>
        void RemoveUserByConnectionID(string connectionID);

        /// <summary>
        /// RemoveUserByUserID
        /// </summary>
        /// <param name="userId"></param>
        void RemoveUserByUserID(string userId);

        /// <summary>
        /// GetUserFromConnectionsByUserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        HubUserContextEntity GetUserFromConnectionsByUserID(string userId);

        
    }
}
