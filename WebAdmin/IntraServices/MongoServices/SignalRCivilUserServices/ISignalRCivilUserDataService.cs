namespace WebAdmin.IntraServices
{
    /// <summary>
    /// ISignalRCivilUserDataService
    /// </summary>
    public interface ISignalRCivilUserDataService
    {
        /// <summary>
        /// MongoMessages
        /// </summary>
        public ISignalROnlineCivilUserRepository MongoSignalRCivilUserRepository { get; }
    }
}
