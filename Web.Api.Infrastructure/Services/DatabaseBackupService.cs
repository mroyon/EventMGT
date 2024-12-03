
using BDO.DataAccessObjects.ExtendedEntities;
using System.Threading.Tasks;
using BDO;
using BDO.Core.DataAccessObjects.Models;
using Microsoft.AspNetCore.Http;
using BDO.Core.Base;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using BDO.Core.DataAccessObjects.CommonEntities;
using System.DirectoryServices;
using System.Configuration;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Vml;
using System.IO;
using System.Security.AccessControl;

namespace Web.Core.Frame.Interfaces.Services
{
    internal sealed partial class DatabaseBackupService : IDatabaseBackupService
    {

        private readonly IConfiguration _config;
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly string _connectionString;
        internal DatabaseBackupService(IConfiguration config
            , IHttpContextAccessor contextAccessor
            , IHttpClientFactory IHttpClienFactory
            , IJwtTokenValidator jwtTokenValidator
            , IStringCompression stringCompression
            )
        {
            _contextAccessor = contextAccessor;
            _config = config;
            _jwtTokenValidator = jwtTokenValidator;
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// BackupDatabaseAsync
        /// </summary>
        /// <param name="backupFilePath"></param>
        /// <returns></returns>
        public async Task BackupDatabaseAsync(string backupFilePath)
        {
            try
            {
                if (!Directory.Exists(backupFilePath))
                {
                    Directory.CreateDirectory(backupFilePath);
                    SetFullAccessPermissions(backupFilePath);
                }

                var builder = new SqlConnectionStringBuilder(_connectionString);
                string databaseName = builder.InitialCatalog;
                var query = $"BACKUP DATABASE [{databaseName}] TO DISK = @BackupFilePath";
                string defaultPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                backupFilePath = !string.IsNullOrEmpty(backupFilePath) ? backupFilePath : defaultPath;
                string filepathFull = System.IO.Path.Combine(backupFilePath, databaseName + "_" + DateTime.Now.ToString("ddMMyyyyhhmm") + ".bak");

                if (System.IO.File.Exists(filepathFull))
                {
                    File.Delete(filepathFull);
                }

                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BackupFilePath", filepathFull);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void SetFullAccessPermissions(string folderPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            DirectorySecurity security = directoryInfo.GetAccessControl();

            // Add full access permission for everyone
            security.AddAccessRule(new FileSystemAccessRule(
                "Everyone",
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow
            ));

            // Apply the updated security settings
            directoryInfo.SetAccessControl(security);

            Console.WriteLine("Full access permissions granted to 'Everyone'.");
        }
    }
}
