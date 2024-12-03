using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class BackupResponse : UseCaseResponseMessage
    {
        //public gen_eventcategoryEntity _gen_EventCategory { get; }

        //public IEnumerable<gen_eventcategoryEntity> _gen_EventCategoryList { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public BackupResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        //public BackupResponse(IEnumerable<gen_eventcategoryEntity> gen_EventCategoryList, bool success = false, string message = null) : base(success, message)
        //{
        //    _gen_EventCategoryList = gen_EventCategoryList;
        //}
        
        //public BackupResponse(gen_eventcategoryEntity gen_EventCategory, bool success = false, string message = null) : base(success, message)
        //{
        //    _gen_EventCategory = gen_EventCategory;
        //}

        public BackupResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
