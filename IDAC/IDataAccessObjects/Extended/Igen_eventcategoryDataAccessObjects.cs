using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface Igen_unitDataAccessObjects
    {
		 
		Task<IList<gen_dropdownEntity>> GetDataForDropDownByUserId(gen_unitEntity gen_eventcategory, CancellationToken cancellationToken);
        Task<gen_unitEntity> GetUnitByUserId(string userId, CancellationToken cancellationToken);


    }
}
