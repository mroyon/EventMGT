
using BDO.DataAccessObjects.ExtendedEntities;
using System.Threading.Tasks;
using BDO;
using BDO.Core.DataAccessObjects.Models;
using Microsoft.AspNetCore.Http;
using BDO.Core.Base;

namespace Web.Core.Frame.Interfaces.Services
{
    public interface IDatabaseBackupService
    {
        Task BackupDatabaseAsync(string backupFilePath);
    }
}
