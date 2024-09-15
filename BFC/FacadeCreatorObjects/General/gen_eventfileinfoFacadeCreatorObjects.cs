

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class gen_eventfileinfoFCC
    { 
	
		public gen_eventfileinfoFCC()
        {
		
        }
		
		public static Igen_eventfileinfoFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            Igen_eventfileinfoFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["Igen_eventfileinfoFacadeObjects"] as Igen_eventfileinfoFacadeObjects;
    
                if (facade == null)
                {
                    facade = new gen_eventfileinfoFacadeObjects();
                    context.Items["Igen_eventfileinfoFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new gen_eventfileinfoFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}