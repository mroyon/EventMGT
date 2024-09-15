using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface Igen_eventinfoDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> AddWithFiles(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
		
        Task<long> UpdateWithFiles(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);


        #endregion Save Update Delete List




        Task<IList<gen_eventinfoEntity>> SearchEventInfo(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);

    }
}
