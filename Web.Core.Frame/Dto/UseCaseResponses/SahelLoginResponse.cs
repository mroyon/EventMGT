using BDO.Core.DataAccessObjects.ExtendedEntities;
using System.Collections.Generic;
using Web.Core.Frame.Interfaces;
 
namespace Web.Core.Frame.Dto.UseCaseResponses
{
    public class SahelLoginResponse : UseCaseResponseMessage 
    {
        public string RefreshToken { get; }
        public Error Errors { get; }
        public string accessToken { get; }
        public int expiresIn { get; }
        public AjaxResponse _ajaxresponse { get; }


        public SahelLoginResponse(Error errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public SahelLoginResponse(bool ss, string Token, int ExpiresIn, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            accessToken = Token;
            expiresIn = ExpiresIn;
            RefreshToken = refreshToken;
        }

        public SahelLoginResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }

    }
}
