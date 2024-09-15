using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class Gen_EventInfoResponse : UseCaseResponseMessage
    {
        public gen_eventinfoEntity _gen_EventInfo { get; }

        public IEnumerable<gen_eventinfoEntity> _gen_EventInfoList { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public Gen_EventInfoResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public Gen_EventInfoResponse(IEnumerable<gen_eventinfoEntity> gen_EventInfoList, bool success = false, string message = null) : base(success, message)
        {
            _gen_EventInfoList = gen_EventInfoList;
        }
        
        public Gen_EventInfoResponse(gen_eventinfoEntity gen_EventInfo, bool success = false, string message = null) : base(success, message)
        {
            _gen_EventInfo = gen_EventInfo;
        }

        public Gen_EventInfoResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
