using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface Igen_eventfileinfoDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
		
        Task<long> Update(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
        
        Task<long> Delete(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<gen_eventfileinfoEntity> listAdded, IList<gen_eventfileinfoEntity> listUpdated, IList<gen_eventfileinfoEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<gen_eventfileinfoEntity>> GetAll(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
		
        Task<IList<gen_eventfileinfoEntity>> GetAllByPages(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<gen_eventfileinfoEntity> GetSingle(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<gen_eventfileinfoEntity>> GAPgListView(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
