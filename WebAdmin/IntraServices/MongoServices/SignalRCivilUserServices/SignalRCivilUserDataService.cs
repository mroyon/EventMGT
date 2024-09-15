using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAdmin.Providers;
using WebAdmin.Services;

namespace WebAdmin.IntraServices
{
    /// <summary>
    /// SignalRCivilUserDataService
    /// </summary>
    public class SignalRCivilUserDataService : ISignalRCivilUserDataService
    {
        private readonly MongoContextProvider _mongoContextProvider;
        private readonly IConfiguration _configuration;
        private readonly IUserProfileParserService _iUserProfileParserService;

        /// <summary>
        /// SignalRCivilUserDataService
        /// </summary>
        /// <param name="mongoContextProvider"></param>
        /// <param name="iUserProfileParserService"></param>
        /// <param name="configuration"></param>
        public SignalRCivilUserDataService(
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
        public ISignalROnlineCivilUserRepository MongoSignalRCivilUserRepository => new SignalROnlineCivilUserRepository(_mongoContextProvider.MongoDatabase, _iUserProfileParserService, _configuration);
    }
}
