using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class BackupRequest : IUseCaseRequest<BackupResponse>
    {
        public backupEntity Objbackup { get; }
        
        public BackupRequest(backupEntity objbackup)
        {
            Objbackup = objbackup;
        }
    }
}
