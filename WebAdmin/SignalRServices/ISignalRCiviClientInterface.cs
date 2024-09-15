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
    /// ISignalRCiviClientInterface
    /// </summary>
    public interface ISignalRCiviClientInterface
    {
         /// <summary>
        /// ParticipantConnectedSuccessfullyCivil
        /// </summary>
        /// <param name="connectionID"></param>
        /// <param name="UserEmail"></param>
        /// <returns></returns>
        Task ParticipantConnectedSuccessfullyCivil(string ConnectionId, string UserEmail);







        //PACI AUTHENTICAITON INTERFACE

        /// <summary>
        /// PostAuthenticationProcessCallCivil
        /// </summary>
        /// <param name="civilid"></param>
        /// <param name="keyparam"></param>
        /// <param name="userdatapaci"></param>
        /// <param name="userdata"></param>
        /// <param name="pacipersonaldata"></param>
        /// <returns></returns>
        Task PostAuthenticationProcessCallCivil(string civilid, string keyparam, string userdatapaci, string userdata, string pacipersonaldata);


        /// <summary>
        /// PostUnAuthorizedProcessCallCivil
        /// </summary>
        /// <param name="keyparam"></param>
        /// <param name="civilid"></param>
        /// <returns></returns>
        Task PostUnAuthorizedProcessCallCivil(string keyparam, string civilid);



        //PACI AUTHENTICAITON INTERFACE
        /// <summary>
        /// PostMsgToClientForConnectionIDUpdated
        /// </summary>
        /// <param name="civilid"></param>
        /// <param name="keyparam"></param>
        /// <param name="connectionid"></param>
        /// <param name="OldcCnnectionid"></param>
        /// <returns></returns>
        Task PostMsgToClientForConnectionIDUpdated(string civilid, string keyparam, string connectionid, string OldcCnnectionid);
    }
}
