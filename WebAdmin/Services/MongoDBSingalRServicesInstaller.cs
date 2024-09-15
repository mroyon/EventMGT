using BDO.DataAccessObjects.ExtendedEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAdmin.IntraServices;
using WebAdmin.Providers;

namespace WebAdmin.Services
{
    /// <summary>
    /// MongoDBSingalRServicesInstaller
    /// </summary>
    public class MongoDBSingalRServicesInstaller : IInstaller
    {
        /// <summary>
        /// InstallServices
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //var mongoDBSettingsOnlineUserSignalRMsg = configuration.GetSection(nameof(MongoDBSettingsSignalRServices)).Get<MongoDBSettingsSignalRServices>();
            //services.AddSingleton<MongoContextProvider>();



            //services.AddScoped<ISignalRCivilUserDataService, SignalRCivilUserDataService>();
            //services.AddScoped<ISignalRUserDataService, SignalRUserDataService>();
            //services.AddScoped<ISignalRQRUserDataService, SignalRQRUserDataService>();

        }
    }
}
