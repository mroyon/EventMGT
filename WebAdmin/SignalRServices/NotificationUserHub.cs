using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebAdmin.SignalRServices
{
    /// <summary>
    /// NotificationUserHub
    /// </summary>
    public class NotificationUserHub : Hub
    {
        private readonly IUserConnectionManager _userConnectionManager;

        /// <summary>
        /// NotificationUserHub
        /// </summary>
        /// <param name="userConnectionManager"></param>
        public NotificationUserHub(IUserConnectionManager userConnectionManager)
        {
            _userConnectionManager = userConnectionManager;
        }

        /// <summary>
        /// GetConnectionId
        /// </summary>
        /// <returns></returns>
        public string GetConnectionId()
        {
            var httpContext = this.Context.GetHttpContext();
            var userId = httpContext.Request.Query["userId"];
            _userConnectionManager.KeepUserConnection(userId, Context.ConnectionId);

            return Context.ConnectionId;
        }

        /// <summary>
        /// OnDisconnectedAsync
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        //Called when a connection with the hub is terminated.
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            //get the connectionId
            var connectionId = Context.ConnectionId;
            _userConnectionManager.RemoveUserConnection(connectionId);
            var value = await Task.FromResult(0);//adding dump code to follow the template of Hub > OnDisconnectedAsync
        }
    }
}
