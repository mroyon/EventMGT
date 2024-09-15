namespace WebAdmin.IntraServices
{
    /// <summary>
    /// IMessagePushDataService
    /// </summary>
    public interface ISignalRUserDataService
    {
        /// <summary>
        /// MongoMessages
        /// </summary>
        public ISignalROnlineUserRepository MongoSignalRUserRepository { get; }
    }
}
