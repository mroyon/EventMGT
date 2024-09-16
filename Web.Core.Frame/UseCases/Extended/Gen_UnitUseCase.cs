using CLL.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.Interfaces.Services;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.Dto;
using AppConfig.HelperClasses;
using Web.Core.Frame.Helpers;
using System.Security.Claims;
using static AppConfig.HelperClasses.applicationEnamNConstants;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.SecurityModels;

namespace Web.Core.Frame.UseCases
{
    public sealed partial class Gen_UnitUseCase 
    {
       
        
        
        /// <summary>
		/// GetDataForDropDown Gen_EventCategory
		/// </summary>
		/// <param name="response"></param>
		public async Task<bool> GetDataForDropDownByUserId(Gen_UnitRequest message, IDDLRequestHandler<Gen_UnitResponse> outputPort)
		{
			CancellationToken cancellationToken = new CancellationToken();
			try
			{
				IList<gen_dropdownEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.gen_unitFCC.GetFacadeCreate(_contextAccessor).GetDataForDropDownByUserId(message.Objgen_unit, cancellationToken);
				
				outputPort.GetDropDown(new Gen_UnitResponse(new AjaxResponse(oblist.Count>0?oblist[0].RETURN_KEY:0, oblist), true, null));
				return true;
				
			}
			catch (Exception ex)
			{
				Gen_UnitResponse objResponse = new Gen_UnitResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
				"500",
				ex.Message));
				_logger.LogInformation(JsonConvert.SerializeObject(objResponse));
				outputPort.GetDropDown(objResponse);
				return true;
			}
		}

        
    }
}