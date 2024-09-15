using BDO.Core.DataAccessObjects.Models;
using BDO.DataAccessObjects.ExtendedEntities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
 
namespace WebAdmin.IntraServices
{ 
    /// <summary>
    /// ISignalROnlineCivilUserRepository
    /// </summary>
    public interface ISignalROnlineCivilUserRepository
    {

        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        Task<HubCivilUserContextEntity> AddeOnlineUser(HubCivilUserContextEntity User);


        /// <summary>
        /// AddeOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        Task<HubCivilUserContextEntity> AddeOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code, string codecivilid);


        /// <summary>
        /// UpdateOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        Task<HubCivilUserContextEntity> UpdateOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code, string codecivilid);


        /// <summary>
        /// UpdateOnlineUserAfterQR
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="objKeyParam"></param>
        /// <param name="objKeyParam"></param>
        /// <returns></returns>
        Task<HubCivilUserContextEntity> UpdateOnlineUserAfterCivil(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code, string codecivilid, PaciKeyParamsValuesEntity objKeyParam);


        /// <summary>
        /// RemoveOnlineUser
        /// </summary>
        /// <param name="httpCtx"></param>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        Task<HubCivilUserContextEntity> RemoveOnlineUser(Microsoft.AspNetCore.Http.HttpContext httpCtx, string connectionid, string code, string codecivilid);


        /// <summary>
        /// GetOnlineUserListFromDB
        /// </summary>
        /// <returns></returns>
        Task<List<HubCivilUserContextEntity>> GetOnlineUserListFromDB();




        /// <summary>
        /// FindByConnectionIDOrCode
        /// </summary>
        /// <param name="connectionid"></param>
        /// <param name="code"></param>
        /// <param name="codecivilid"></param>
        /// <returns></returns>
        Task<HubCivilUserContextEntity> FindByConnectionIDOrCode(string connectionid, string code, string codecivilid);




        /// <summary>
        /// FindByUserName
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<HubCivilUserContextEntity> FindBySessionID(HubCivilUserContextEntity user);




    }
}
