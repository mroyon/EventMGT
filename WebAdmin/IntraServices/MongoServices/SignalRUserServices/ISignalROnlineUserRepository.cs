using BDO.Core.DataAccessObjects.Models;
using BDO.DataAccessObjects.ExtendedEntities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// IMessageRepository
    /// </summary>
    public interface ISignalROnlineUserRepository
    {

        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<HubUserContextEntity> AddeOnlineUser(HubUserContextEntity User);


        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <returns></returns>
        Task<HubUserContextEntity> AddeOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid);


        /// <summary>
        /// UpdateOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <returns></returns>
        Task<HubUserContextEntity> UpdateOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid);


        /// <summary>
        /// RemoveOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <returns></returns>
        Task<HubUserContextEntity> RemoveOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid);


        /// <summary>
        /// FindByEmailAddress
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<HubUserContextEntity> FindByEmailAddress(HubUserContextEntity user);


        /// <summary>
        /// GetOnlineUserListFromDB
        /// </summary>
        /// <returns></returns>
        Task<List<HubUserContextEntity>> GetOnlineUserListFromDB();


        /// <summary>
        /// FindByUserName
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<HubUserContextEntity> FindByUserName(HubUserContextEntity user);



    }
}
