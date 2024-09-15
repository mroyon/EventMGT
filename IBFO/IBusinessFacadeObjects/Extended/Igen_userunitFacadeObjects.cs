

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    public partial interface Igen_userunitFacadeObjects 
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList_Ext(List<gen_userunitEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<gen_userunitEntity>> GetAll_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<gen_userunitEntity>> GetAllByPages_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<gen_userunitEntity> GetSingle_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<gen_userunitEntity>> GAPgListView_Ext(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
