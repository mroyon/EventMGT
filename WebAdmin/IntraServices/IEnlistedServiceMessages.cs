using BDO.DataAccessObjects.ExtendedEntities;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// IEmailSender
    /// </summary>
    public interface IEnlistedServiceMessages
    {
        /// <summary>
        /// SahelEnlistedServiceRejectMessagesList
        /// </summary>
        /// <returns></returns>
        Task<List<string>> SahelEnlistedServiceRejectMessagesList();



        /// <summary>
        /// SahelEnlistedServiceApprovedMessagesList
        /// </summary>
        /// <returns></returns>
        Task<List<string>> SahelEnlistedServiceApprovedMessagesList();
    }
}
