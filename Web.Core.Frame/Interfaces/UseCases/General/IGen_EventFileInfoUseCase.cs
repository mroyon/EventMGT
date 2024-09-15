using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IGen_EventFileInfoUseCase : IUseCaseRequestHandler<Gen_EventFileInfoRequest, Gen_EventFileInfoResponse>
    {
        Task<bool> Save(Gen_EventFileInfoRequest message, ICRUDRequestHandler<Gen_EventFileInfoResponse> outputPort);

        Task<bool> Update(Gen_EventFileInfoRequest message, ICRUDRequestHandler<Gen_EventFileInfoResponse> outputPort);

        Task<bool> Delete(Gen_EventFileInfoRequest message, ICRUDRequestHandler<Gen_EventFileInfoResponse> outputPort);


        Task<bool> GetSingle(Gen_EventFileInfoRequest message, ICRUDRequestHandler<Gen_EventFileInfoResponse> outputPort);

        Task<bool> GetAll(Gen_EventFileInfoRequest message, ICRUDRequestHandler<Gen_EventFileInfoResponse> outputPort);


        Task<bool> GetAllPaged(Gen_EventFileInfoRequest message, ICRUDRequestHandler<Gen_EventFileInfoResponse> outputPort);

        Task<bool> GetListView(Gen_EventFileInfoRequest message, ICRUDRequestHandler<Gen_EventFileInfoResponse> outputPort);
        
        
            
    }
}
