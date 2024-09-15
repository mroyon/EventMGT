using System.Threading.Tasks;
using Web.Core.Frame.Dto.UseCaseRequests;
using Web.Core.Frame.Dto.UseCaseResponses;
using Web.Core.Frame.Presenters;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public interface ILoginUseCase : IUseCaseRequestHandler<LoginRequest, LoginResponse>
    {
        Task<bool> HandleForSahel(LoginRequest message, ISahelLoginHandler<SahelLoginResponse> outputPort);

        Task<bool> ChangePassword(PasswordChangeRequest message, ISahelLoginHandler<SahelLoginResponse> outputPort);
    }
}
