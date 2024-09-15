
using BDO.DataAccessObjects.ExtendedEntities;
using System.Threading.Tasks;

namespace Web.Core.Frame.Interfaces.Services
{
    public interface IEmailSender
    {
        /// <summary>
        /// SendEmailAsync
        /// </summary>
        /// <param name="emailobject"></param>
        /// <param name="fromaddress"></param>
        /// <param name="frompassword"></param>
        /// <returns></returns>
        Task SendEmailAsync(EmailEntity emailobject, string fromaddress = null, string frompassword = null);
    }
}
