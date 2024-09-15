

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "Igen_unitFacadeObjects")]
    public partial interface Igen_unitFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(gen_unitEntity gen_unit, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(gen_unitEntity gen_unit, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(gen_unitEntity gen_unit, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<gen_unitEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<gen_unitEntity>> GetAll(gen_unitEntity gen_unit, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<gen_unitEntity>> GetAllByPages(gen_unitEntity gen_unit, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        [OperationContract]
        Task<long> SaveMasterDetgen_eventinfo(gen_unitEntity Master, List<gen_eventinfoEntity> DetailList, CancellationToken cancellationToken);

        [OperationContract]
        Task<long> SaveMasterDetgen_userunit(gen_unitEntity Master, List<gen_userunitEntity> DetailList, CancellationToken cancellationToken);

        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<gen_unitEntity> GetSingle(gen_unitEntity gen_unit, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<gen_unitEntity>> GAPgListView(gen_unitEntity gen_unit, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
        #region for Dropdown 
		[OperationContract]
		Task<IList<gen_dropdownEntity>> GetDataForDropDown(gen_unitEntity gen_unit, CancellationToken cancellationToken); 
		#endregion
    
    }
}
