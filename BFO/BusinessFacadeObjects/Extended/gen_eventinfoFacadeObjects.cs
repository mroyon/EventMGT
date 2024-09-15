
using AppConfig.ConfigDAAC;
using BDO.Core.Base;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BFO.Base;
using DAC.Core.CoreFactory;
using IBFO.Core.IBusinessFacadeObjects.General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace BFO.Core.BusinessFacadeObjects.General
{
    public sealed partial class gen_eventinfoFacadeObjects 
    {
	
	
		
		#region Business Facade
		
		#region Save Update Delete List	
		
		async Task<long> Igen_eventinfoFacadeObjects.AddWithFiles(BDO.Core.DataAccessObjects.Models.gen_eventinfoEntity gen_eventinfo, System.Threading.CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.Creategen_eventinfoDataAccess().AddWithFiles(gen_eventinfo, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_eventinfoFacade.AddWithFiles"));
            }
        } 

		  async Task<long> Igen_eventinfoFacadeObjects.UpdateWithFiles(BDO.Core.DataAccessObjects.Models.gen_eventinfoEntity gen_eventinfo, System.Threading.CancellationToken cancellationToken)
		{
			try
            {
				return await DataAccessFactory.Creategen_eventinfoDataAccess().UpdateWithFiles(gen_eventinfo, cancellationToken);
			}
            
            catch (Exception ex)
            {
                throw GetFacadeException(ex, SourceOfException("Igen_eventinfoFacade.UpdateWithFiles"));
            }
        }
		
		
		
        
		#endregion Save Update Delete List	
		
		
    
        
    
    
        #endregion
	}
}