using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class Gen_EventCategoryResponse : UseCaseResponseMessage
    {
        public gen_eventcategoryEntity _gen_EventCategory { get; }

        public IEnumerable<gen_eventcategoryEntity> _gen_EventCategoryList { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public Gen_EventCategoryResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public Gen_EventCategoryResponse(IEnumerable<gen_eventcategoryEntity> gen_EventCategoryList, bool success = false, string message = null) : base(success, message)
        {
            _gen_EventCategoryList = gen_EventCategoryList;
        }
        
        public Gen_EventCategoryResponse(gen_eventcategoryEntity gen_EventCategory, bool success = false, string message = null) : base(success, message)
        {
            _gen_EventCategory = gen_EventCategory;
        }

        public Gen_EventCategoryResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
