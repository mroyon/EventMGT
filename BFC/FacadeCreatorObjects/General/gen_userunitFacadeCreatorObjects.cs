

using BFO.Core.BusinessFacadeObjects.General;
using IBFO.Core.IBusinessFacadeObjects.General;
using Microsoft.AspNetCore.Http;

namespace BFC.Core.FacadeCreatorObjects.General
{
    public class gen_userunitFCC
    { 
	
		public gen_userunitFCC()
        {
		
        }
		
		public static Igen_userunitFacadeObjects GetFacadeCreate(IHttpContextAccessor httpContextAccessor)
        {
            Igen_userunitFacadeObjects facade = null;
            var context = httpContextAccessor.HttpContext;			
            
            if (context != null)
            {
                facade = context.Items["Igen_userunitFacadeObjects"] as Igen_userunitFacadeObjects;
    
                if (facade == null)
                {
                    facade = new gen_userunitFacadeObjects();
                    context.Items["Igen_userunitFacadeObjects"] = facade;
                }
            }
            else
            {
                facade = new gen_userunitFacadeObjects();
                return facade;
            }
            return facade;
        }
		
		
	}
}