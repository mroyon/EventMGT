﻿

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;

namespace IBFO.Core.IBusinessFacadeObjects.General
{
    public partial interface Igen_servicestatusFacadeObjects 
    { 
		[OperationContract]
		Task<IList<gen_dropdownEntity>> GetDataForDropDownRefWithService(gen_servicestatusEntity gen_servicestatus, CancellationToken cancellationToken); 
    
    }
}
