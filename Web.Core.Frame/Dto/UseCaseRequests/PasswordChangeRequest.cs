using Web.Core.Frame.CustomIdentityManagers;
using Web.Core.Frame.Dto.UseCaseResponses;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.Dto.UseCaseRequests
{ 
    public class PasswordChangeRequest : IUseCaseRequest<SahelLoginResponse>
    {
        public string UserName { get; }
        public string Password { get; }
        public string NewPassword { get; }
        public string ConfirmNewPassword { get; }
        public string RemoteIpAddress { get; }


        public PasswordChangeRequest(string userName, string password, string newpassword, string confirmnewpassword, string remoteIpAddress)
        {
            UserName = userName;
            Password = password;
            NewPassword = newpassword;
            ConfirmNewPassword = confirmnewpassword;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
