using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAdmin.Providers;
using WebAdmin.Services;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// MessagePushDataService
    /// </summary>
    public class SignalRQRUserDataService : ISignalRQRUserDataService
    {
        private readonly MongoContextProvider _mongoContextProvider;
        private readonly IConfiguration _configuration;
        private readonly IUserProfileParserService _iUserProfileParserService;

        /// <summary>
        /// SignalRUserDataService
        /// </summary>
        /// <param name="mongoContextProvider"></param>
        /// <param name="iUserProfileParserService"></param>
        /// <param name="configuration"></param>
        public SignalRQRUserDataService(
            MongoContextProvider mongoContextProvider,
            IUserProfileParserService iUserProfileParserService,
            IConfiguration configuration)
        {
            _iUserProfileParserService = iUserProfileParserService;
            _mongoContextProvider = mongoContextProvider;
            _configuration = configuration;
        }

        /// <summary>
        /// MongoMessages
        /// </summary>
        public ISignalROnlineQRUserRepository MongoSignalRQRUserRepository => new SignalROnlineQRUserRepository(_mongoContextProvider.MongoDatabase, _iUserProfileParserService, _configuration);
    }
}
