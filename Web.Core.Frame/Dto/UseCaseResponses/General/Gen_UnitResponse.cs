using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class Gen_UnitResponse : UseCaseResponseMessage
    {
        public gen_unitEntity _gen_Unit { get; }

        public IEnumerable<gen_unitEntity> _gen_UnitList { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public Gen_UnitResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public Gen_UnitResponse(IEnumerable<gen_unitEntity> gen_UnitList, bool success = false, string message = null) : base(success, message)
        {
            _gen_UnitList = gen_UnitList;
        }
        
        public Gen_UnitResponse(gen_unitEntity gen_Unit, bool success = false, string message = null) : base(success, message)
        {
            _gen_Unit = gen_Unit;
        }

        public Gen_UnitResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
