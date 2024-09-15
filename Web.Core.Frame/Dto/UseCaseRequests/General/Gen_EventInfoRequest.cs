using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class Gen_EventInfoRequest : IUseCaseRequest<Gen_EventInfoResponse>
    {
        public gen_eventinfoEntity Objgen_eventinfo { get; }
        
        public Gen_EventInfoRequest(gen_eventinfoEntity objgen_eventinfo)
        {
            Objgen_eventinfo = objgen_eventinfo;
        }
    }
}
