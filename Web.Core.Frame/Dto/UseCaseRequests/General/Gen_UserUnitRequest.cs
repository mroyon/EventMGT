using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class Gen_UserUnitRequest : IUseCaseRequest<Gen_UserUnitResponse>
    {
        public gen_userunitEntity Objgen_userunit { get; }
        
        public Gen_UserUnitRequest(gen_userunitEntity objgen_userunit)
        {
            Objgen_userunit = objgen_userunit;
        }
    }
}
