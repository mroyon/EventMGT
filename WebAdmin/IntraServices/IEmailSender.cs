using System;
using System.Threading.Tasks;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// IEmailSender
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        ///SendEmailAsync
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="fromaddress"></param>
        /// <param name="frompassword"></param>
        /// <returns></returns>
        Task SendEmailAsync(string email, string subject, string message, string fromaddress = null, string frompassword = null);
    }
}
