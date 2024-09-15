using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IGen_EventInfoUseCase : IUseCaseRequestHandler<Gen_EventInfoRequest, Gen_EventInfoResponse>
    {
        Task<bool> SaveExt(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort);
    }
}
