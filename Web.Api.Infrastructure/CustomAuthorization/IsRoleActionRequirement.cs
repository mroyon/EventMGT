using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Security.Claims;
using System.Threading;
using Microsoft.Net.Http.Headers;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.DataProtection;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using Web.Core.Frame.Interfaces.Services;

namespace Web.Api.Infrastructure.CustomAuthorization
{
    public class IsRoleActionRequirement : IAuthorizationRequirement
    {
        IHttpContextAccessor _contextAccessor;
        IConfiguration _configuration;
        IJwtTokenValidator _iJwtTokenValidator;

        public async Task<bool> Pass(IHttpContextAccessor contextAccessor, IConfiguration configuration, AuthorizationHandlerContext context, IJwtTokenValidator iJwtTokenValidator)
        {
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _iJwtTokenValidator = iJwtTokenValidator;

            string strRoles = string.Empty;
            CancellationToken cancellationToken = new CancellationToken();

            var endpointas = contextAccessor.HttpContext.GetEndpoint();

            var u = contextAccessor.HttpContext.User;

            if(endpointas == null)
                return await Task.FromResult(false);

            if (endpointas.DisplayName.ToLower().Contains("webadmin"))
            {
                var descriptor = endpointas.Metadata.GetMetadata<ControllerActionDescriptor>();
                var controllerName = descriptor.ControllerName;
                var actionName = descriptor.ActionName;

                if (controllerName.ToUpper().Contains("HUB"))
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    var roleClaims = context.User.Claims.Where(c => c.Type == ClaimTypes.Role)?.ToList();
                    if (roleClaims != null && roleClaims.Count > 0)
                    {
                        strRoles = string.Join(",", roleClaims.Select(x => x.Value).ToArray());
                        var obj = await BFC.Core.FacadeCreatorObjects.Security.owin_rolepermissionFCC.GetFacadeCreate(contextAccessor).GetRolesPermissionByParams(new BDO.Core.DataAccessObjects.SecurityModels.owin_rolepermissionExtEntity()
                        {
                            rolename = strRoles,
                            ControllerName = controllerName + "/" + actionName
                        }, cancellationToken);
                        return await Task.FromResult(obj == null ? false : true);
                    }
                    else
                        return await Task.FromResult(false);
                }
            }
            else
            {
                var descriptor = endpointas.Metadata.GetMetadata<ControllerActionDescriptor>();
                var controllerName = descriptor.ControllerName;
                var actionName = descriptor.ActionName;


                string _bearer_token = contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("bearer ", "");

                if (!string.IsNullOrEmpty(_bearer_token))
                {
                   var roleClaims = _iJwtTokenValidator.GetPrincipalFromToken(_bearer_token);
                    strRoles = string.Join(",", roleClaims.Claims.Where(p => p.Type == ClaimTypes.Role).Select(x => x.Value).ToArray());

                    var obj = await BFC.Core.FacadeCreatorObjects.Security.owin_rolepermissionFCC.GetFacadeCreate(contextAccessor).GetRolesPermissionByParams(new BDO.Core.DataAccessObjects.SecurityModels.owin_rolepermissionExtEntity()
                    {
                        rolename = strRoles,
                        ControllerName = controllerName + "/" + actionName
                    }, cancellationToken);
                    return await Task.FromResult(obj == null ? false : true);
                }
                return await Task.FromResult(false);
              
            }

            if (context.Resource is AuthorizationFilterContext filterContext)
            {
                return await Task.FromResult(true);
            }

            if (context.Resource is DefaultHttpContext httpContext)
            {
                return await Task.FromResult(true);
            }


            return await Task.FromResult(false);
        }
    }
}


