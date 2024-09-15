using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IGen_UnitUseCase : IUseCaseRequestHandler<Gen_UnitRequest, Gen_UnitResponse>
    {
        Task<bool> Save(Gen_UnitRequest message, ICRUDRequestHandler<Gen_UnitResponse> outputPort);

        Task<bool> Update(Gen_UnitRequest message, ICRUDRequestHandler<Gen_UnitResponse> outputPort);

        Task<bool> Delete(Gen_UnitRequest message, ICRUDRequestHandler<Gen_UnitResponse> outputPort);


        Task<bool> GetSingle(Gen_UnitRequest message, ICRUDRequestHandler<Gen_UnitResponse> outputPort);

        Task<bool> GetAll(Gen_UnitRequest message, ICRUDRequestHandler<Gen_UnitResponse> outputPort);


        Task<bool> GetAllPaged(Gen_UnitRequest message, ICRUDRequestHandler<Gen_UnitResponse> outputPort);

        Task<bool> GetListView(Gen_UnitRequest message, ICRUDRequestHandler<Gen_UnitResponse> outputPort);


        Task<bool> GetDataForDropDown(Gen_UnitRequest message, IDDLRequestHandler<Gen_UnitResponse> outputPort);

    }
}
