

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "Igen_eventfileinfoFacadeObjects")]
    public partial interface Igen_eventfileinfoFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<gen_eventfileinfoEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<gen_eventfileinfoEntity>> GetAll(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<gen_eventfileinfoEntity>> GetAllByPages(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<gen_eventfileinfoEntity> GetSingle(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<gen_eventfileinfoEntity>> GAPgListView(gen_eventfileinfoEntity gen_eventfileinfo, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
            
    }
}
