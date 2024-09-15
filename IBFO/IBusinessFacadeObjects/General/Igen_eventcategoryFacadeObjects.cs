

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "Igen_eventcategoryFacadeObjects")]
    public partial interface Igen_eventcategoryFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<gen_eventcategoryEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<gen_eventcategoryEntity>> GetAll(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<gen_eventcategoryEntity>> GetAllByPages(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        [OperationContract]
        Task<long> SaveMasterDetgen_eventinfo(gen_eventcategoryEntity Master, List<gen_eventinfoEntity> DetailList, CancellationToken cancellationToken);

        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<gen_eventcategoryEntity> GetSingle(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<gen_eventcategoryEntity>> GAPgListView(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
        #region for Dropdown 
		[OperationContract]
		Task<IList<gen_dropdownEntity>> GetDataForDropDown(gen_eventcategoryEntity gen_eventcategory, CancellationToken cancellationToken); 
		#endregion
    
    }
}
