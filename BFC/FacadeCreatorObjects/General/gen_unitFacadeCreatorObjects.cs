

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class gen_unitFCC
    { 
	
		public gen_unitFCC()
        {
		
        }
		
		public static Igen_unitFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            Igen_unitFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["Igen_unitFacadeObjects"] as Igen_unitFacadeObjects;
    
                if (facade == null)
                {
                    facade = new gen_unitFacadeObjects();
                    context.Items["Igen_unitFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new gen_unitFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}