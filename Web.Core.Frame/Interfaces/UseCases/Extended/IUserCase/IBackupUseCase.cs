using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases.Extended.IUserCase
{
    public partial interface IBackupUseCase : IUseCaseRequestHandler<BackupRequest, BackupResponse>
    {
        Task<bool> BackupDatabase(BackupRequest message, ICRUDRequestHandler<BackupResponse> outputPort);
    }
}