

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class gen_eventcategoryFCC
    { 
	
		public gen_eventcategoryFCC()
        {
		
        }
		
		public static Igen_eventcategoryFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            Igen_eventcategoryFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["Igen_eventcategoryFacadeObjects"] as Igen_eventcategoryFacadeObjects;
    
                if (facade == null)
                {
                    facade = new gen_eventcategoryFacadeObjects();
                    context.Items["Igen_eventcategoryFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new gen_eventcategoryFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}