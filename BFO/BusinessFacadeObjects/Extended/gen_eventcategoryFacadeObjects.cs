
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
    public sealed partial class gen_unitFacadeObjects 
    {
	
		
    
        #region for Dropdown 
		async Task<IList<gen_dropdownEntity>> Igen_unitFacadeObjects.GetDataForDropDownByUserId(gen_unitEntity gen_eventcategory, CancellationToken cancellationToken)
		{
			try
			{
				return await DataAccessFactory.Creategen_unitDataAccess().GetDataForDropDownByUserId(gen_eventcategory,cancellationToken);
			}
			catch (Exception ex)
			{
				throw GetFacadeException(ex, SourceOfException("IList<gen_eventcategoryEntity> Igen_eventcategoryFacade.GetDataForDropDownByUserId")); 
			}
		}
		#endregion
    
        
    
    
      
	}
}