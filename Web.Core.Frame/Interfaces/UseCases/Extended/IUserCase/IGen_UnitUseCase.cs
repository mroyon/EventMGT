using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IGen_UnitUseCase 
    {
        Task<bool> GetDataForDropDownByUserId(Gen_UnitRequest message, IDDLRequestHandler<Gen_UnitResponse> outputPort);
    
    }
}
