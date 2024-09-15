

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class gen_eventinfoFCC
    { 
	
		public gen_eventinfoFCC()
        {
		
        }
		
		public static Igen_eventinfoFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            Igen_eventinfoFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["Igen_eventinfoFacadeObjects"] as Igen_eventinfoFacadeObjects;
    
                if (facade == null)
                {
                    facade = new gen_eventinfoFacadeObjects();
                    context.Items["Igen_eventinfoFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new gen_eventinfoFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}