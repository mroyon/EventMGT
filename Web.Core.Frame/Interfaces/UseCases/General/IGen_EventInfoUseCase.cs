using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IGen_EventInfoUseCase : IUseCaseRequestHandler<Gen_EventInfoRequest, Gen_EventInfoResponse>
    {
        Task<bool> Save(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort);

        Task<bool> Update(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort);

        Task<bool> Delete(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort);


        Task<bool> GetSingle(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort);

        Task<bool> GetAll(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort);


        Task<bool> GetAllPaged(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort);

        Task<bool> GetListView(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort);
        
        
        		Task<bool> GetDataForDropDown(Gen_EventInfoRequest message, IDDLRequestHandler<Gen_EventInfoResponse> outputPort);
    
    }
}
