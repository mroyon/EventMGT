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
    public sealed partial class Gen_EventInfoUseCase : IGen_EventInfoUseCase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IJwtFactory _jwtFactory;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly ILogger<Gen_EventInfoUseCase> _logger;
        private dataTableButtonPanel objDTBtnPanel = new dataTableButtonPanel();
        public Error _errors { get; set; }

        public Gen_EventInfoUseCase(
            IHttpContextAccessor contextAccessor,
            IJwtFactory jwtFactory,
            IStringLocalizerFactory factory,
            ILoggerFactory loggerFactory)
        {
            _contextAccessor = contextAccessor;
            _jwtFactory = jwtFactory;
            _logger = loggerFactory.CreateLogger<Gen_EventInfoUseCase>();

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public Task<bool> Handle(Gen_EventInfoRequest message, IOutputPort<Gen_EventInfoResponse> outputPort)
        {
            throw new Exception("Not Implemented");
        }

        public async Task<bool> GetAll(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                IList<gen_eventinfoEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                .GetAll(message.Objgen_eventinfo, cancellationToken);

                if (oblist != null && oblist.Count > 0)
                {
                    outputPort.GetAll(new Gen_EventInfoResponse(oblist.ToList(), true));
                    return true;
                }
                else
                {
                    Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetAll(objResponse);
                    return false;
                }                
            }
            catch (Exception ex)
            {
                Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetAll(objResponse);
                return true;
            }
        }

        public async Task<bool> GetAllPaged(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                IList<gen_eventinfoEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                .GetAllByPages(message.Objgen_eventinfo, cancellationToken);

                if (oblist != null && oblist.Count > 0)
                {
                    outputPort.GetAllPaged(new Gen_EventInfoResponse(oblist.ToList(), true));
                    return true;
                }
                else
                {
                    Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetAllPaged(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetAllPaged(objResponse);
                return true;
            }
        }

        public async Task<bool> GetListView(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {

                IList<gen_eventinfoEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                .GAPgListView(message.Objgen_eventinfo, cancellationToken);
                
                    List<dataTableButtonModel> btnActionList = new List<dataTableButtonModel>();
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.New_GET));
                    btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.Edit_GET));
                    btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.Delete_GET));
                    btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.GetSingle_GET));
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.CUSTOM, _sharedLocalizer["PROCESS"], "StpOrganizationEntity/userprocess"));
                    //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.CUSTOM, _sharedLocalizer["SEARCH"], "StpOrganizationEntity/usersearch"));
                    
                    var data = (from t in oblist
                                select new
                                {
									 t.eventid,
									 t.eventcategoryid,
									 t.eventcode,
									 t.eventname,
									 t.eventstartdate,
									 t.eventenddate,
									 t.eventdescription,
									 t.eventdescription1,
									 t.eventdescription2,
									 t.eventspecialnote,
									 t.isdeleted,
									 t.eventorganizedby,
									 t.ex_nvarchar3,
                                    datatablebuttonscode = objDTBtnPanel.genDTBtnPanel(message.Objgen_eventinfo.ControllerName, t.eventid, "eventid", _contextAccessor.HttpContext.User.Identity as ClaimsIdentity, btnActionList, _contextAccessor)
                                }).ToList();

                    outputPort.GetListView(new Gen_EventInfoResponse(new AjaxResponse(oblist.Count>0?oblist[0].RETURN_KEY:0, data), true, null));
                    return true;
               
            }
            catch (Exception ex)
            {
                Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetListView(objResponse);
                return true;
            }
        }

        public async Task<bool> GetSingle(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {
                gen_eventinfoEntity objSingle = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                .GetSingle(message.Objgen_eventinfo, cancellationToken);
                if (objSingle != null)
                {
                    outputPort.GetSingle(new Gen_EventInfoResponse(objSingle, true));
                    return true;
                }
                else
                {
                    Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
                     "404",
                     _sharedLocalizer["NO_DATA_FOUND"]));
                    _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                    outputPort.GetSingle(objResponse);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetSingle(objResponse);
                return true;
            }
        }

        public async Task<bool> Save(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(message));
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                i = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                    .AddWithFiles(message.Objgen_eventinfo, cancellationToken);
                    
                outputPort.Save(new Gen_EventInfoResponse(new AjaxResponse("200", _sharedLocalizer["DATA_SAVE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_SAVE_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Save(objResponse);
                return true;
            }
        }

        public async Task<bool> Update(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                i = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                    .UpdateWithFiles(message.Objgen_eventinfo, cancellationToken);
                
                outputPort.Update(new Gen_EventInfoResponse(new AjaxResponse("200", _sharedLocalizer["DATA_UPDATE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                        ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_UPDATE_ERROR"], new Error(
                       "500",
                       ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Update(objResponse);
                return true;
            }
        }

        public async Task<bool> Delete(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            long? i = null;
            try
            {
                i = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                    .Delete(message.Objgen_eventinfo, cancellationToken);
                outputPort.Delete(new Gen_EventInfoResponse(new AjaxResponse("200", _sharedLocalizer["DATA_DELETE_CONFIRMATION"].Value, CLL.LLClasses._Status._statusSuccess, CLL.LLClasses._Status._titleInformation, "/"
                       ), true, null));
                return true;
            }
            catch (Exception ex)
            {
                Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_DELETE_ERROR"], new Error(
                         "500",
                         ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.Delete(objResponse);
                return true;
            }
        }
        
        
        
        /// <summary>
		/// GetDataForDropDown Gen_EventInfo
		/// </summary>
		/// <param name="response"></param>
		public async Task<bool> GetDataForDropDown(Gen_EventInfoRequest message, IDDLRequestHandler<Gen_EventInfoResponse> outputPort)
		{
			CancellationToken cancellationToken = new CancellationToken();
			try
			{
				IList<gen_dropdownEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor).GetDataForDropDown(message.Objgen_eventinfo, cancellationToken);
				if (oblist != null && oblist.Count > 0)
				{
					outputPort.GetDropDown(new Gen_EventInfoResponse(new AjaxResponse(oblist[0].RETURN_KEY, oblist), true, null));
					return true;
				}
				else
				{
					Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["NO_DATA_FOUND"], new Error(
					"404",
					_sharedLocalizer["NO_DATA_FOUND"]));
					_logger.LogInformation(JsonConvert.SerializeObject(objResponse));
					outputPort.GetDropDown(objResponse);
					return false;
				}
			}
			catch (Exception ex)
			{
				Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
				"500",
				ex.Message));
				_logger.LogInformation(JsonConvert.SerializeObject(objResponse));
				outputPort.GetDropDown(objResponse);
				return true;
			}
		}

        public async Task<bool> SearchEventInfo(Gen_EventInfoRequest message, ICRUDRequestHandler<Gen_EventInfoResponse> outputPort)
        {
            CancellationToken cancellationToken = new CancellationToken();
            try
            {

                IList<gen_eventinfoEntity> oblist = await BFC.Core.FacadeCreatorObjects.General.gen_eventinfoFCC.GetFacadeCreate(_contextAccessor)
                .SearchEventInfo(message.Objgen_eventinfo, cancellationToken);

                //List<dataTableButtonModel> btnActionList = new List<dataTableButtonModel>();
                //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.New_GET));
                //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.Edit_GET));
                //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.Delete_GET));
                //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.GetSingle_GET));
                //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.CUSTOM, _sharedLocalizer["PROCESS"], "StpOrganizationEntity/userprocess"));
                //btnActionList.Add(new dataTableButtonModel(basicCRUDButtons.CUSTOM, _sharedLocalizer["SEARCH"], "StpOrganizationEntity/usersearch"));

                var data = (from t in oblist
                            select new
                            {
                                t.eventid,
                                t.eventcategoryid,
                                t.eventcode,
                                t.eventname,
                                t.eventstartdate,
                                t.eventenddate,
                                t.eventdescription,
                                t.eventdescription1,
                                t.eventdescription2,
                                t.eventspecialnote,
                                t.isdeleted,
                                t.eventorganizedby,
                                t.ex_nvarchar3,
                                t.ex_nvarchar1
                                //datatablebuttonscode = objDTBtnPanel.genDTBtnPanel(message.Objgen_eventinfo.ControllerName, t.eventid, "eventid", _contextAccessor.HttpContext.User.Identity as ClaimsIdentity, btnActionList, _contextAccessor)
                            }).ToList();

                outputPort.GetListView(new Gen_EventInfoResponse(new AjaxResponse(oblist.Count > 0 ? oblist[0].RETURN_KEY : 0, data), true, null));
                return true;

            }
            catch (Exception ex)
            {
                Gen_EventInfoResponse objResponse = new Gen_EventInfoResponse(false, _sharedLocalizer["DATA_FETCH_ERROR"], new Error(
                    "500",
                    ex.Message));
                _logger.LogInformation(JsonConvert.SerializeObject(objResponse));
                outputPort.GetListView(objResponse);
                return true;
            }
        }
    }
}