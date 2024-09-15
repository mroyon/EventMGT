

using Web.Core.Frame.Dto.UseCaseResponses;

namespace Web.Core.Frame.Interfaces
{
    public interface ISahelLoginHandler<in SahelLoginResponse>
    {
        void SahelLogin(SahelLoginResponse response);

        void ChangePassword(SahelLoginResponse response);
    }
}
