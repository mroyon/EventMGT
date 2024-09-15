
using BDO.DataAccessObjects.ExtendedEntities;
using System.Threading.Tasks;
using BDO;
using BDO.Core.DataAccessObjects.Models;
using Microsoft.AspNetCore.Http;
using BDO.Core.Base;

namespace Web.Core.Frame.Interfaces.Services
{
    public interface IADUserService
    {

        /// <summary>
        /// GetADInfoByMilitaryID
        /// </summary>
        /// <param name="militaryid"></param>
        /// <returns></returns>
        Task<string> GetADInfoByMilitaryID(string militaryid);
    }
}
