using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace WebAdmin.FilterAndAttributes
{
    public class AddAuthorizeFiltersControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.DisplayName.ToLower().Contains("webapi"))
            {
                controller.Filters.Add(new AuthorizeFilter("KAFSecurityPolicy"));
            }
            else
            {
                if (controller.ControllerName == "Account" || controller.ControllerName == "Home")
                    controller.Filters.Add(new AuthorizeFilter("defaultpolicy"));
                else
                    controller.Filters.Add(new AuthorizeFilter("KAFSecurityPolicy"));
            }
        }
    }
}
