

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "Igen_userunitFacadeObjects")]
    public partial interface Igen_userunitFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(gen_userunitEntity gen_userunit, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<gen_userunitEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<gen_userunitEntity>> GetAll(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<gen_userunitEntity>> GetAllByPages(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<gen_userunitEntity> GetSingle(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<gen_userunitEntity>> GAPgListView(gen_userunitEntity gen_userunit, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
