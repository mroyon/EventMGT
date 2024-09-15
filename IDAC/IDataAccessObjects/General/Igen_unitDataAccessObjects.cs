using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface Igen_unitDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(gen_unitEntity gen_unit, CancellationToken cancellationToken);
		
        Task<long> Update(gen_unitEntity gen_unit, CancellationToken cancellationToken);
        
        Task<long> Delete(gen_unitEntity gen_unit, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<gen_unitEntity> listAdded, IList<gen_unitEntity> listUpdated, IList<gen_unitEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<gen_unitEntity>> GetAll(gen_unitEntity gen_unit, CancellationToken cancellationToken);
		
        Task<IList<gen_unitEntity>> GetAllByPages(gen_unitEntity gen_unit, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        Task<long> SaveMasterDetgen_eventinfo(gen_unitEntity masterEntity, IList<gen_eventinfoEntity> listAdded, IList<gen_eventinfoEntity> listUpdated, IList<gen_eventinfoEntity> listDeleted, CancellationToken cancellationToken);

        Task<long> SaveMasterDetgen_userunit(gen_unitEntity masterEntity, IList<gen_userunitEntity> listAdded, IList<gen_userunitEntity> listUpdated, IList<gen_userunitEntity> listDeleted, CancellationToken cancellationToken);

        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<gen_unitEntity> GetSingle(gen_unitEntity gen_unit, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<gen_unitEntity>> GAPgListView(gen_unitEntity gen_unit, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
        #region for Dropdown 
		Task<IList<gen_dropdownEntity>> GetDataForDropDown(gen_unitEntity gen_unit, CancellationToken cancellationToken); 
		#endregion
       
        
        
        
        
    }
}
