using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class Gen_UnitRequest : IUseCaseRequest<Gen_UnitResponse>
    {
        public gen_unitEntity Objgen_unit { get; }
        
        public Gen_UnitRequest(gen_unitEntity objgen_unit)
        {
            Objgen_unit = objgen_unit;
        }
    }
}
