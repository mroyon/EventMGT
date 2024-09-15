using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebAdmin.SignalRServices
{
    /// <summary>
    /// MessageHub
    /// </summary>
    public class MessageHub : Hub
    {
        /// <summary>
        /// SendMessage
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string user, string message)
        {
            if (string.IsNullOrEmpty(user))
                await Clients.All.SendAsync("ReceiveMessageHandler", message);
            else
                await Clients.User(user).SendAsync("ReceiveMessageHandler", message);
        }
    }
}
