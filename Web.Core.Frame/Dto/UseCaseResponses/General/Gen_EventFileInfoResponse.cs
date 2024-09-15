using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class Gen_EventFileInfoResponse : UseCaseResponseMessage
    {
        public gen_eventfileinfoEntity _gen_EventFileInfo { get; }

        public IEnumerable<gen_eventfileinfoEntity> _gen_EventFileInfoList { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public Gen_EventFileInfoResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public Gen_EventFileInfoResponse(IEnumerable<gen_eventfileinfoEntity> gen_EventFileInfoList, bool success = false, string message = null) : base(success, message)
        {
            _gen_EventFileInfoList = gen_EventFileInfoList;
        }
        
        public Gen_EventFileInfoResponse(gen_eventfileinfoEntity gen_EventFileInfo, bool success = false, string message = null) : base(success, message)
        {
            _gen_EventFileInfo = gen_EventFileInfo;
        }

        public Gen_EventFileInfoResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
