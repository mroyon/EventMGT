namespace WebAdmin.IntraServices
{
    /// <summary>
    /// IMessagePushDataService
    /// </summary>
    public interface ISignalRQRUserDataService
    {
        /// <summary>
        /// MongoMessages
        /// </summary>
        public ISignalROnlineQRUserRepository MongoSignalRQRUserRepository { get; }
    }
}
