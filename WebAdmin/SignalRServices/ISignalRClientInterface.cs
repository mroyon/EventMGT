using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using BDO.DataAccessObjects.ExtendedEntities;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAdmin.SignalRServices
{
    /// <summary>
    /// WPFClientInterface
    /// </summary>
    public interface ISignalRClientInterface
    {
        /// <summary>
        /// ParticipantConnectedSuccessfully
        /// </summary>
        /// <param name="connectionID"></param>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        Task ParticipantConnectedSuccessfully(string ConnectionId, string UserEmail);

        /// <summary>
        /// CompleteConnectionParticipantList
        /// </summary>
        /// <param name="userlistJson"></param>
        /// <returns></returns>
        Task CompleteConnectionParticipantList(string userlistJson);

        /// <summary>
        /// DeletedConnectedParticipant
        /// </summary>
        /// <param name="userlistJson"></param>
        /// <returns></returns>
        Task DeletedConnectedParticipant(string userlistJson);


        /// <summary>
        /// SendMsgtoSpecificClient
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task SendMsgtoSpecificClient( string msg,string username);



        /// <summary>
        /// SendNotificationToClients
        /// </summary>
        /// <param name="mailsubject"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        Task SendNotificationToClients(string mailsubject, string msg);




        //PACI AUTHENTICAITON INTERFACE

        /// <summary>
        /// PostAuthenticationProcessCall
        /// </summary>
        /// <param name="keyParam"></param>
        /// <param name="userdata"></param>
        /// <returns></returns>
        Task PostAuthenticationProcessCall(string keyParam, string userdata);


       /// <summary>
       /// PostUnAuthorizedProcessCall
       /// </summary>
       /// <param name="keyParam"></param>
       /// <param name="userdata"></param>
       /// <returns></returns>
        Task PostUnAuthorizedProcessCall(string keyParam, string userdata);


    }
}
