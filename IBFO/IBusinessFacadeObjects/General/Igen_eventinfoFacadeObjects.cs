

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    [ServiceContract(Name = "Igen_eventinfoFacadeObjects")]
    public partial interface Igen_eventinfoFacadeObjects : IDisposable
    { 
		#region Save Update Delete List 
		
		
		[OperationContract]
        Task<long> Add(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
        
		[OperationContract]
		Task<long> Update(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken );
		
		[OperationContract]
		Task<long> Delete(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
        
        [OperationContract]
        Task<long> SaveList(List<gen_eventinfoEntity> list , CancellationToken cancellationToken);
		
		
		#endregion Save Update Delete List
		
		#region GetAll	
		
		[OperationContract]
        Task<IList<gen_eventinfoEntity>> GetAll(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
		
		[OperationContract]
        Task<IList<gen_eventinfoEntity>> GetAllByPages(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
     
		#endregion GetAll
		
        #region Save Master/Details	
        
        [OperationContract]
        Task<long> SaveMasterDetgen_eventfileinfo(gen_eventinfoEntity Master, List<gen_eventfileinfoEntity> DetailList, CancellationToken cancellationToken);

        #endregion Save Master/Details	
        
        #region Simple load Single Row
        [OperationContract]
        Task<gen_eventinfoEntity> GetSingle(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
         #endregion 
         
         #region ForListView Paged Method
         [OperationContract]
         Task<IList<gen_eventinfoEntity>> GAPgListView(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
         #endregion
         
        #region Extras Reviewed, Published, Archived
        #endregion 
        
        
        #region for Dropdown 
		[OperationContract]
		Task<IList<gen_dropdownEntity>> GetDataForDropDown(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken); 
		#endregion
    
    }
}
