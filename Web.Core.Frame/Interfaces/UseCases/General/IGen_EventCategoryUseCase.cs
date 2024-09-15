using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IGen_EventCategoryUseCase : IUseCaseRequestHandler<Gen_EventCategoryRequest, Gen_EventCategoryResponse>
    {
        Task<bool> Save(Gen_EventCategoryRequest message, ICRUDRequestHandler<Gen_EventCategoryResponse> outputPort);

        Task<bool> Update(Gen_EventCategoryRequest message, ICRUDRequestHandler<Gen_EventCategoryResponse> outputPort);

        Task<bool> Delete(Gen_EventCategoryRequest message, ICRUDRequestHandler<Gen_EventCategoryResponse> outputPort);


        Task<bool> GetSingle(Gen_EventCategoryRequest message, ICRUDRequestHandler<Gen_EventCategoryResponse> outputPort);

        Task<bool> GetAll(Gen_EventCategoryRequest message, ICRUDRequestHandler<Gen_EventCategoryResponse> outputPort);


        Task<bool> GetAllPaged(Gen_EventCategoryRequest message, ICRUDRequestHandler<Gen_EventCategoryResponse> outputPort);

        Task<bool> GetListView(Gen_EventCategoryRequest message, ICRUDRequestHandler<Gen_EventCategoryResponse> outputPort);


        Task<bool> GetDataForDropDown(Gen_EventCategoryRequest message, IDDLRequestHandler<Gen_EventCategoryResponse> outputPort);

    }
}
