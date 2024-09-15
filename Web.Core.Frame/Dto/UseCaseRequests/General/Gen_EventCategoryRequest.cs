using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class Gen_EventCategoryRequest : IUseCaseRequest<Gen_EventCategoryResponse>
    {
        public gen_eventcategoryEntity Objgen_eventcategory { get; }
        
        public Gen_EventCategoryRequest(gen_eventcategoryEntity objgen_eventcategory)
        {
            Objgen_eventcategory = objgen_eventcategory;
        }
    }
}
