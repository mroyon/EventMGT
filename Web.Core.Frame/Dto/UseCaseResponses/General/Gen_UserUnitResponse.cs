using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class Gen_UserUnitResponse : UseCaseResponseMessage
    {
        public gen_userunitEntity _gen_UserUnit { get; }

        public IEnumerable<gen_userunitEntity> _gen_UserUnitList { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public Gen_UserUnitResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public Gen_UserUnitResponse(IEnumerable<gen_userunitEntity> gen_UserUnitList, bool success = false, string message = null) : base(success, message)
        {
            _gen_UserUnitList = gen_UserUnitList;
        }
        
        public Gen_UserUnitResponse(gen_userunitEntity gen_UserUnit, bool success = false, string message = null) : base(success, message)
        {
            _gen_UserUnit = gen_UserUnit;
        }

        public Gen_UserUnitResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
