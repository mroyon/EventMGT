

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    public partial interface Igen_eventinfoFacadeObjects : IDisposable
    { 
		[OperationContract]
        Task<long> AddWithFiles(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken);
        [OperationContract]
        Task<long> UpdateWithFiles(gen_eventinfoEntity gen_eventinfo, CancellationToken cancellationToken );
		
    
    }
}
