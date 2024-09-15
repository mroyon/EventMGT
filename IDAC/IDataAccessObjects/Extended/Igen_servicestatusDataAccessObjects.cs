using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface Igen_servicestatusDataAccessObjects
    {
		 
		Task<IList<gen_dropdownEntity>> GetDataForDropDownRefWithService(gen_servicestatusEntity gen_servicestatus, CancellationToken cancellationToken); 
        
    }
}
