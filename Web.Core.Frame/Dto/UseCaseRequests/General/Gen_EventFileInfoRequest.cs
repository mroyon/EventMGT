using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class Gen_EventFileInfoRequest : IUseCaseRequest<Gen_EventFileInfoResponse>
    {
        public gen_eventfileinfoEntity Objgen_eventfileinfo { get; }
        
        public Gen_EventFileInfoRequest(gen_eventfileinfoEntity objgen_eventfileinfo)
        {
            Objgen_eventfileinfo = objgen_eventfileinfo;
        }
    }
}
