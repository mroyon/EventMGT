using System.Net;
using Web.Core.Frame.RequestResponse.UseCaseResponses;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.Serialization;
using Web.Core.Frame.Helpers;
using Web.Core.Frame.Dto.UseCaseResponses;

namespace Web.Core.Frame.Presenters
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LoginPresenter : IOutputPort<LoginResponse>, ISahelLoginHandler<SahelLoginResponse>
    {
        public JsonContentResult ContentResult { get; }
        public object Result { get; set; }
        public LoginPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(LoginResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new LoginResponse(response.AccessToken, response.RefreshToken, true)) : JsonSerializer.SerializeObject(response.Errors);
        }

        public void SahelLogin(SahelLoginResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new SahelLoginResponse(true, response.accessToken, response.expiresIn, response.RefreshToken, true)) : JsonSerializer.SerializeObject(response.Errors);
        }

        public void ChangePassword(SahelLoginResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotAcceptable);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new SahelLoginResponse(response._ajaxresponse, response.Success)) : JsonSerializer.SerializeObject(response.Errors);
            Result = response.Success ? response._ajaxresponse as object : response.Errors;
        }

    }
}
