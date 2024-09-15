using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace IDAC.Core.IDataAccessObjects.General
{
	public partial interface Igen_eventcategoryDataAccessObjects
    {
		 
		#region Save Update Delete List Single Entity	
        
        Task<long> Add(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
		
        Task<long> Update(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
        
        Task<long> Delete(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
		
        Task<long> SaveList(IList<gen_eventcategoryEntity> listAdded, IList<gen_eventcategoryEntity> listUpdated, IList<gen_eventcategoryEntity> listDeleted, CancellationToken cancellationToken);
        
		#endregion Save Update Delete List
		
		
		#region GetAll	
		Task<IList<gen_eventcategoryEntity>> GetAll(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
		
        Task<IList<gen_eventcategoryEntity>> GetAllByPages(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
        
		#endregion GetAll
		
		#region SaveMasterDetails
        Task<long> SaveMasterDetgen_eventinfo(gen_eventcategoryEntity masterEntity, IList<gen_eventinfoEntity> listAdded, IList<gen_eventinfoEntity> listUpdated, IList<gen_eventinfoEntity> listDeleted, CancellationToken cancellationToken);

        #endregion SaveMasterDetails
        
         #region Simple load Single Row
         Task<gen_eventcategoryEntity> GetSingle(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         Task<IList<gen_eventcategoryEntity>> GAPgListView(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion        
        
        
        #region for Dropdown 
		Task<IList<gen_dropdownEntity>> GetDataForDropDown(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken); 
		#endregion
       
        
        
        
        
    }
}
