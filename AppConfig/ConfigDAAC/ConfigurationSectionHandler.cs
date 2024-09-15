using AppConfig.EncryptionHandler;
using AppConfig.HelperClasses;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Xml;

namespace AppConfig.ConfigDAAC
{
    public class AppConfiguration
    {
        public readonly string _connectionString = string.Empty;
        public readonly string _saltString = string.Empty;
        public readonly string _mongoDBString = string.Empty;
        public readonly string _redisDBString = string.Empty;
        public readonly string _oracleTNSstring = string.Empty;
        public AppConfiguration()
        {
            EncryptionHelper objenc = new EncryptionHelper();

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            _saltString = root.GetSection("AuthSettings").GetSection("SecretKey").Value;
            _mongoDBString = root.GetSection("Serilog").GetSection("WriteTo").GetSection("0").GetSection("Args").GetSection("databaseUrl").Value;
            _redisDBString = root.GetSection("RedisConnectionStrings").GetSection("redisServerUrl").Value;
            //var appSetting = root.GetSection("ApplicationSettings");
        }
        public string ConnectionString
        {
            get => _connectionString;
        }

        public string SaltString
        {
            get => _saltString;
        }
    }
}
