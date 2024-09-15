using BDO.DataAccessObjects.ExtendedEntities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace WebAdmin.Providers
{
    public class MongoContextProvider
    {
        private readonly MongoClient _MongoClientClient;
        private readonly IMongoDatabase _MongoDatabase;

        /// <summary>
        /// MongoContextProvider
        /// </summary>
        /// <param name="configuration"></param>
        public MongoContextProvider(IConfiguration configuration)
        {
            var mongoDBSettingsOnlineUser = configuration.GetSection(nameof(MongoDBSettingsSignalRServices)).Get<MongoDBSettingsSignalRServices>();

            _MongoClientClient = new MongoClient(mongoDBSettingsOnlineUser.ConnectionString);
            _MongoDatabase = _MongoClientClient.GetDatabase(mongoDBSettingsOnlineUser.CoreSignalRDatabaseName);
        }

        /// <summary>
        /// MongoClientClient
        /// </summary>
        public IMongoClient MongoClientClient => _MongoClientClient;
        /// <summary>
        /// _MongoDatabase
        /// </summary>
        public IMongoDatabase MongoDatabase => _MongoDatabase;
    }
}
