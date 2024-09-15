using BDO.Core.DataAccessObjects.Models;
using BDO.DataAccessObjects.ExtendedEntities;
using MongoDB.Driver.Core.Connections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAdmin.IntraServices
{
    /// <summary> 
    /// IMessageRepository
    /// </summary>
    public interface ISignalROnlineQRUserRepository
    {

        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<HubQRUserContextEntity> AddeOnlineUser(HubQRUserContextEntity User);


        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<HubQRUserContextEntity> AddeOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code);


        /// <summary>
        /// UpdateOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<HubQRUserContextEntity> UpdateOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code);


        /// <summary>
        /// UpdateOnlineUserAfterQR
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="objKeyParam"></param>
        /// <returns></returns>
        Task<HubQRUserContextEntity> UpdateOnlineUserAfterQR(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code, PaciKeyParamsValuesEntity objKeyParam);


        /// <summary>
        /// RemoveOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<HubQRUserContextEntity> RemoveOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code);


        /// <summary>
        /// FindByConnectionIDOrCode
        /// </summary>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<HubQRUserContextEntity> FindByConnectionIDOrCode(string connectionid, string code);


        /// <summary>
        /// GetOnlineUserListFromDB
        /// </summary>
        /// <returns></returns>
        Task<List<HubQRUserContextEntity>> GetOnlineUserListFromDB();


        /// <summary>
        /// FindByUserName
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<HubQRUserContextEntity> FindBySessionID(HubQRUserContextEntity user);



    }
}
