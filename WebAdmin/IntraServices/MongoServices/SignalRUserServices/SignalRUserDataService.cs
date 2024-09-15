using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAdmin.Providers;
using WebAdmin.Services;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// MessagePushDataService
    /// </summary>
    public class SignalRUserDataService : ISignalRUserDataService
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
        public SignalRUserDataService(
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
        public ISignalROnlineUserRepository MongoSignalRUserRepository => new SignalROnlineUserRepository(_mongoContextProvider.MongoDatabase, _iUserProfileParserService, _configuration);
    }
}
