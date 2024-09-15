using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface Igen_userunitDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
		
        Task<long> Update(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
        
        Task<long> Delete(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<gen_userunitEntity> listAdded, IList<gen_userunitEntity> listUpdated, IList<gen_userunitEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<gen_userunitEntity>> GetAll(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
		
        Task<IList<gen_userunitEntity>> GetAllByPages(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<gen_userunitEntity> GetSingle(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<gen_userunitEntity>> GAPgListView(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
               
        
        
        
        
    }
}
