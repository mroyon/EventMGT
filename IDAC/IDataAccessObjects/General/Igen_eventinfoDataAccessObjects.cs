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
        
        Task<long> Add(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
		
        Task<long> Update(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
        
        Task<long> Delete(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<gen_eventinfoEntity> listAdded, IList<gen_eventinfoEntity> listUpdated, IList<gen_eventinfoEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<gen_eventinfoEntity>> GetAll(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
		
        Task<IList<gen_eventinfoEntity>> GetAllByPages(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        Task<long> SaveMasterDetgen_eventfileinfo(gen_eventinfoEntity masterEntity, IList<gen_eventfileinfoEntity> listAdded, IList<gen_eventfileinfoEntity> listUpdated, IList<gen_eventfileinfoEntity> listDeleted, CancellationToken cancellationToken);

        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<gen_eventinfoEntity> GetSingle(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<gen_eventinfoEntity>> GAPgListView(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
        #region for Dropdown 
		Task<IList<gen_dropdownEntity>> GetDataForDropDown(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken); 
		#endregion
       
        
        
        
        
    }
}
