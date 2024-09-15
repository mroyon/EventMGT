using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IGen_UserUnitUseCase : IUseCaseRequestHandler<Gen_UserUnitRequest, Gen_UserUnitResponse>
    {
        Task<bool> Save(Gen_UserUnitRequest message, ICRUDRequestHandler<Gen_UserUnitResponse> outputPort);

        Task<bool> Update(Gen_UserUnitRequest message, ICRUDRequestHandler<Gen_UserUnitResponse> outputPort);

        Task<bool> Delete(Gen_UserUnitRequest message, ICRUDRequestHandler<Gen_UserUnitResponse> outputPort);


        Task<bool> GetSingle(Gen_UserUnitRequest message, ICRUDRequestHandler<Gen_UserUnitResponse> outputPort);

        Task<bool> GetAll(Gen_UserUnitRequest message, ICRUDRequestHandler<Gen_UserUnitResponse> outputPort);


        Task<bool> GetAllPaged(Gen_UserUnitRequest message, ICRUDRequestHandler<Gen_UserUnitResponse> outputPort);

        Task<bool> GetListView(Gen_UserUnitRequest message, ICRUDRequestHandler<Gen_UserUnitResponse> outputPort);
        
        
            
    }
}
