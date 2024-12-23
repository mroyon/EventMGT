﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using CLL.Localization;
using Web.Core.Frame.Interfaces.UseCases;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.Presenters;
using Microsoft.Extensions.Configuration;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.CommonEntities;
using WebAdmin.Providers;
using Newtonsoft.Json;
using System.IO;
using CLL.LLClasses.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.StaticFiles;
using Org.BouncyCastle.Asn1.Ocsp;
using Web.Core.Frame.UseCases;
using Microsoft.AspNetCore.Hosting;
using BDO.DataAccessObjects.ExtendedEntities;
using Microsoft.AspNet.SignalR.Client.Http;
using System.Linq;
using SharpCompress.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using AppConfig.EncryptionHandler;
using Microsoft.AspNetCore;
using Microsoft.Reporting.NETCore;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Drawing.Text;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Gen_EventInfoController
    /// </summary>
    /// 


    [RequestFormLimits(MultipartBodyLengthLimit = 2000000000)]
    [RequestSizeLimit(2000000000)]
    [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Gen_EventInfoController : BaseController
    {
        private List<gen_eventfileinfoEntity> _objEventFilesReport = new List<gen_eventfileinfoEntity>();

        private readonly IGen_EventInfoUseCase _gen_EventInfoUseCase;
        private readonly Gen_EventInfoPresenter _gen_EventInfoPresenter;

        private readonly IGen_EventFileInfoUseCase _gen_EventFileInfoUseCase;
        private readonly Gen_EventFileInfoPresenter _gen_EventFileInfoPresenter;

        private readonly ICacheProvider _cacheProvider;
        private IWebHostEnvironment _webhost;

        private readonly IGen_EventCategoryUseCase _gen_EventCategoryUseCase;
        private readonly Gen_EventCategoryPresenter _gen_EventCategoryPresenter;
        private readonly IGen_UnitUseCase _gen_UnitUseCase;
        private readonly Gen_UnitPresenter _gen_UnitPresenter;



        private readonly ILogger<Gen_EventInfoController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        private readonly IWebHostEnvironment _webHostEnvironment;


        private readonly IHttpContextAccessor _contextAccessor;

        //to Enable SignalR Inj
        //private readonly IHubContext<HubUserContext> _hubuserContext;
        //private readonly IUserConnectionManager _userConnectionManager;

        /// <summary>
        /// _configuration
        /// </summary>
        public IConfiguration _configuration { get; }

        /// <summary>
        /// Gen_EventInfoController
        /// </summary>
        /// <param name="gen_EventInfoUseCase"></param>
        /// <param name="gen_EventInfoPresenter"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="factory"></param>
        /// <param name="schemeProvider"></param>        
        /// <param name="hubuserContext"></param>
        /// <param name="userConnectionManager"></param>
        /// <param name="cacheProvider"></param>
        /// <param name="gen_EventCategoryUseCase"></param>
        /// <param name="gen_EventCategoryPresenter"></param>
        /// <param name="gen_UnitUseCase"></param>
        /// <param name="gen_UnitPresenter"></param>

        public Gen_EventInfoController(
            IGen_EventInfoUseCase gen_EventInfoUseCase,
            Gen_EventInfoPresenter gen_EventInfoPresenter,
            ILoggerFactory loggerFactory,
            IStringLocalizerFactory factory,
            IAuthenticationSchemeProvider schemeProvider
            //,IHubContext<HubUserContext> hubuserContext
            //,IUserConnectionManager userConnectionManager
            , ICacheProvider cacheProvider
             ,IWebHostEnvironment webhost

             , IGen_EventCategoryUseCase gen_EventCategoryUseCase
            , Gen_EventCategoryPresenter gen_EventCategoryPresenter
, IGen_UnitUseCase gen_UnitUseCase
            , Gen_UnitPresenter gen_UnitPresenter
,
IGen_EventFileInfoUseCase gen_EventFileInfoUseCase
,
Gen_EventFileInfoPresenter gen_EventFileInfoPresenter,
IWebHostEnvironment webHostEnvironment,
IHttpContextAccessor contextAccessor)
        {
            _gen_EventInfoUseCase = gen_EventInfoUseCase;
            _gen_EventInfoPresenter = gen_EventInfoPresenter;
            _logger = loggerFactory.CreateLogger<Gen_EventInfoController>();
            _schemeProvider = schemeProvider;


            _gen_EventCategoryUseCase = gen_EventCategoryUseCase;
            _gen_EventCategoryPresenter = gen_EventCategoryPresenter;
            _gen_UnitUseCase = gen_UnitUseCase;
            _gen_UnitPresenter = gen_UnitPresenter;

            _webhost = webhost;

            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
            _gen_EventFileInfoUseCase = gen_EventFileInfoUseCase;
            _gen_EventFileInfoPresenter = gen_EventFileInfoPresenter;
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }


        /// <summary>
        /// LandingGen_EventInfo
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LandingGen_EventInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            return View("../General/Gen_EventInfo/LandingGen_EventInfo", new gen_eventinfoEntity());
        }

        /// <summary>
        /// ListGen_EventInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ListGen_EventInfo(DtParameters request)
        {
            try
            {
                var draw = request.Draw;
                gen_eventinfoEntity objrequest = new gen_eventinfoEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                objrequest.PageSize = request.Length;
                objrequest.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                objrequest.strCommonSerachParam = request.Search.Value;
                objrequest.ControllerName = "Gen_EventInfo";
                await _gen_EventInfoUseCase.GetListView(new Gen_EventInfoRequest(objrequest), _gen_EventInfoPresenter);
                return Json(_gen_EventInfoPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get View AddGen_EventInfo
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddGen_EventInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userid = claimsIdentity.Claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").FirstOrDefault().Value;

            gen_unitEntity objrequest = new gen_unitEntity();
            objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
            objrequest.BaseSecurityParam.userid = Guid.Parse(userid);
            objrequest.CurrentPage = 1;
            objrequest.PageSize = 10;
            objrequest.SortExpression = " unit asc ";
            objrequest.ControllerName = "Gen_Unit";

            await _gen_UnitUseCase.GetDataForDropDownByUserId(new Gen_UnitRequest(objrequest), _gen_UnitPresenter);
            try
            {
                List<gen_dropdownEntity> Data = (List<gen_dropdownEntity>)(((AjaxResponse)_gen_UnitPresenter.Result).data);
                if (Data.Count == 1)
                {
                    var datagen_unit = (new { Id = Data.FirstOrDefault().Id, Text = Data.FirstOrDefault().Text });
                    ViewBag.preloadedDatagen_unit = JsonConvert.SerializeObject(datagen_unit);
                }
            }
            catch (Exception)
            {

            }

            return View("../General/Gen_EventInfo/AddGen_EventInfo", new gen_eventinfoEntity());
        }

        /// <summary>
        /// POST AddGen_EventInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]

        public async Task<IActionResult> AddGen_EventInfo([FromForm] gen_eventinfoEntity request)
        {
            ModelState.Remove("eventcode");
            ModelState.Remove("eventenddate");

            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            // Process each file
            var objGen_EventFileInfo = new List<gen_eventfileinfoEntity>();
            request.EventfileinfoList = new List<gen_eventfileinfoEntity>();
            if (request.postedFiles != null)
            {
                foreach (var item in request.postedFiles)
                {
                    var file = item.file;
                    var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    gen_eventfileinfoEntity objFile = new gen_eventfileinfoEntity();
                    objFile.filename = fileName;
                    objFile.filetitle = file.FileName;
                    string contentType = string.Empty;
                    new FileExtensionContentTypeProvider().TryGetContentType(file.FileName, out contentType);
                    objFile.filetype = contentType;
                    objFile.extension = Path.GetExtension(filePath); 
                    objFile.filesize = file.Length;
                    objFile.filedescription = item.fileDescription;
                    objFile.BaseSecurityParam = request.BaseSecurityParam;
                    objGen_EventFileInfo.Add(objFile);
                }
            }
            request.eventdescription = RemoveBogusTags(request.eventdescription);
            request.EventfileinfoList = objGen_EventFileInfo;
            await _gen_EventInfoUseCase.SaveExt(new Gen_EventInfoRequest(request), _gen_EventInfoPresenter);
            return _gen_EventInfoPresenter.ContentResult;
        }

        static string RemoveBogusTags(string html)
        {
            string res = "";
            if(!string.IsNullOrEmpty(html))
            {
                // Regular expression to remove <p><br data-mce-bogus="1"></p> tags
                string pattern = @"<p><br\s+data-mce-bogus=""1""></p>";
                html = Regex.Replace(html, pattern, string.Empty);
                string pattern2 = @"<p>&nbsp;</p>";
                res = Regex.Replace(html, pattern2, string.Empty);
            }
            return res;
        }
        /// <summary>
        /// Get View EditGen_EventInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditGen_EventInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventinfoEntity objEntity = new gen_eventinfoEntity();
            objEntity.eventid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventid", input).ToString());
            await _gen_EventInfoUseCase.GetSingle(new Gen_EventInfoRequest(objEntity), _gen_EventInfoPresenter);
            objEntity = _gen_EventInfoPresenter.Result as gen_eventinfoEntity;


            gen_eventcategoryEntity objgen_eventcategoryEntity = new gen_eventcategoryEntity();
            objgen_eventcategoryEntity.eventcategoryid = objEntity.eventcategoryid;
            await _gen_EventCategoryUseCase.GetSingle(new Gen_EventCategoryRequest(objgen_eventcategoryEntity), _gen_EventCategoryPresenter);
            objgen_eventcategoryEntity = ((gen_eventcategoryEntity)_gen_EventCategoryPresenter.Result);
            var datagen_eventcategory = (new { Id = objgen_eventcategoryEntity.eventcategoryid, Text = objgen_eventcategoryEntity.eventcategory });
            ViewBag.preloadedDatagen_eventcategory = JsonConvert.SerializeObject(datagen_eventcategory);


            gen_unitEntity objgen_unitEntity = new gen_unitEntity();
            objgen_unitEntity.unitid = objEntity.eventorganizedby;
            await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objgen_unitEntity), _gen_UnitPresenter);
            objgen_unitEntity = ((gen_unitEntity)_gen_UnitPresenter.Result);
            var datagen_unit = (new { Id = objgen_unitEntity.unitid, Text = objgen_unitEntity.unit });
            ViewBag.preloadedDatagen_unit = JsonConvert.SerializeObject(datagen_unit);


            await _gen_EventFileInfoUseCase.GetAll(new Gen_EventFileInfoRequest(new gen_eventfileinfoEntity() { eventid = objEntity.eventid }), _gen_EventFileInfoPresenter);

            objEntity.EventfileinfoList = _gen_EventFileInfoPresenter.Result as List<gen_eventfileinfoEntity>;

            foreach (var item in objEntity.EventfileinfoList)
            {
                item.FileUrl = $"/uploads/{item.filename}";
            }
            return View("../General/Gen_EventInfo/EditGen_EventInfo", objEntity);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetAllFileByEventId([FromBody] gen_eventinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventinfoEntity objEntity = new gen_eventinfoEntity();
            await _gen_EventInfoUseCase.GetSingle(new Gen_EventInfoRequest(request), _gen_EventInfoPresenter);
            objEntity = _gen_EventInfoPresenter.Result as gen_eventinfoEntity;

            await _gen_EventFileInfoUseCase.GetAll(new Gen_EventFileInfoRequest(new gen_eventfileinfoEntity() { eventid = objEntity.eventid }), _gen_EventFileInfoPresenter);

            objEntity.EventfileinfoList = _gen_EventFileInfoPresenter.Result as List<gen_eventfileinfoEntity>;

            foreach (var item in objEntity.EventfileinfoList)
            {
                item.FileUrl = $"/uploads/{item.filename}";
            }
            return Ok(objEntity.EventfileinfoList);
        }




        /// <summary>
        /// Post EditGen_EventInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> EditGen_EventInfo([FromForm] gen_eventinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }

            ModelState.Remove("eventcode");
            ModelState.Remove("eventenddate");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var objGen_EventFileInfo = new List<gen_eventfileinfoEntity>();
            request.EventfileinfoList = new List<gen_eventfileinfoEntity>();
            if (request.postedFiles != null)
            {
                foreach (var item in request.postedFiles.Where(q => q.eventfileid.HasValue == false).ToList())
                {
                    var file = item.file;
                    var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    gen_eventfileinfoEntity objFile = new gen_eventfileinfoEntity();
                    objFile.filename = fileName;
                    objFile.filetitle = file.FileName;
                    string contentType = string.Empty;
                    new FileExtensionContentTypeProvider().TryGetContentType(file.FileName, out contentType);
                    objFile.filetype = contentType;
                    objFile.extension = Path.GetExtension(filePath); ;
                    objFile.filesize = file.Length;
                    objFile.filedescription = item.fileDescription;
                    objFile.BaseSecurityParam = request.BaseSecurityParam;
                    objGen_EventFileInfo.Add(objFile);
                }
                foreach (var item in request.postedFiles.Where(q => q.eventfileid.HasValue == true).ToList())
                {
                    gen_eventfileinfoEntity objFile = new gen_eventfileinfoEntity();
                    objFile.eventfileid = item.eventfileid;
                    objFile.eventid = item.eventid;
                    objFile.filedescription = item.fileDescription;
                    objFile.BaseSecurityParam = request.BaseSecurityParam;
                    objGen_EventFileInfo.Add(objFile);
                }
            }
            request.EventfileinfoList = objGen_EventFileInfo;
            request.eventdescription = RemoveBogusTags(request.eventdescription);

            await _gen_EventInfoUseCase.Update(new Gen_EventInfoRequest(request), _gen_EventInfoPresenter);
            return _gen_EventInfoPresenter.ContentResult;
        }

        /// <summary>
        /// Get View GetSingleGen_EventInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetSingleGen_EventInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventinfoEntity objEntity = new gen_eventinfoEntity();
            objEntity.eventid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventid", input).ToString());
            await _gen_EventInfoUseCase.GetSingle(new Gen_EventInfoRequest(objEntity), _gen_EventInfoPresenter);
            objEntity = _gen_EventInfoPresenter.Result as gen_eventinfoEntity;

            gen_eventcategoryEntity objgen_eventcategoryEntity = new gen_eventcategoryEntity();
            objgen_eventcategoryEntity.eventcategoryid = objEntity.eventcategoryid;
            await _gen_EventCategoryUseCase.GetSingle(new Gen_EventCategoryRequest(objgen_eventcategoryEntity), _gen_EventCategoryPresenter);
            objgen_eventcategoryEntity = ((gen_eventcategoryEntity)_gen_EventCategoryPresenter.Result);
            var datagen_eventcategory = (new { Id = objgen_eventcategoryEntity.eventcategoryid, Text = objgen_eventcategoryEntity.eventcategory });
            ViewBag.preloadedDatagen_eventcategory = JsonConvert.SerializeObject(datagen_eventcategory);


            gen_unitEntity objgen_unitEntity = new gen_unitEntity();
            objgen_unitEntity.unitid = objEntity.eventorganizedby;
            await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objgen_unitEntity), _gen_UnitPresenter);
            objgen_unitEntity = ((gen_unitEntity)_gen_UnitPresenter.Result);
            var datagen_unit = (new { Id = objgen_unitEntity.unitid, Text = objgen_unitEntity.unit });
            ViewBag.preloadedDatagen_unit = JsonConvert.SerializeObject(datagen_unit);




            return View("../General/Gen_EventInfo/GetSingleGen_EventInfo", _gen_EventInfoPresenter.Result);
        }

        /// <summary>
        /// Get View DeleteGen_EventInfo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_EventInfo([FromQuery(Name = "params")] string input)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            gen_eventinfoEntity objEntity = new gen_eventinfoEntity();
            objEntity.eventid = long.Parse(objClsPrivate.DecodeUrlParamsWithoutURI("eventid", input).ToString());
            await _gen_EventInfoUseCase.GetSingle(new Gen_EventInfoRequest(objEntity), _gen_EventInfoPresenter);
            objEntity = _gen_EventInfoPresenter.Result as gen_eventinfoEntity;

            gen_eventcategoryEntity objgen_eventcategoryEntity = new gen_eventcategoryEntity();
            objgen_eventcategoryEntity.eventcategoryid = objEntity.eventcategoryid;
            await _gen_EventCategoryUseCase.GetSingle(new Gen_EventCategoryRequest(objgen_eventcategoryEntity), _gen_EventCategoryPresenter);
            objgen_eventcategoryEntity = ((gen_eventcategoryEntity)_gen_EventCategoryPresenter.Result);
            var datagen_eventcategory = (new { Id = objgen_eventcategoryEntity.eventcategoryid, Text = objgen_eventcategoryEntity.eventcategory });
            ViewBag.preloadedDatagen_eventcategory = JsonConvert.SerializeObject(datagen_eventcategory);


            gen_unitEntity objgen_unitEntity = new gen_unitEntity();
            objgen_unitEntity.unitid = objEntity.eventorganizedby;
            await _gen_UnitUseCase.GetSingle(new Gen_UnitRequest(objgen_unitEntity), _gen_UnitPresenter);
            objgen_unitEntity = ((gen_unitEntity)_gen_UnitPresenter.Result);
            var datagen_unit = (new { Id = objgen_unitEntity.unitid, Text = objgen_unitEntity.unit });
            ViewBag.preloadedDatagen_unit = JsonConvert.SerializeObject(datagen_unit);




            return View("../General/Gen_EventInfo/DeleteGen_EventInfo", objEntity);
        }

        /// <summary>
        /// Post DeleteGen_EventInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_EventInfo([FromBody] gen_eventinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            /*				 ModelState.Remove("eventid");
                  ModelState.Remove("eventcategoryid");
                  ModelState.Remove("eventcode");
                  ModelState.Remove("eventname");
                  ModelState.Remove("eventstartdate");
                  ModelState.Remove("eventenddate");
                  ModelState.Remove("eventdescription");
                  ModelState.Remove("eventdescription1");
                  ModelState.Remove("eventdescription2");
                  ModelState.Remove("eventspecialnote");
                  ModelState.Remove("isdeleted");
                  ModelState.Remove("eventorganizedby");
                  ModelState.Remove("ex_nvarchar3");
 */
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _gen_EventInfoUseCase.Delete(new Gen_EventInfoRequest(request), _gen_EventInfoPresenter);
            return _gen_EventInfoPresenter.ContentResult;
        }



        /// <summary>
        /// GetDataForDropDown Gen_EventInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetDataForDropDowndGen_EventInfo([FromBody] S2Parameters request)
        {
            try
            {
                gen_eventinfoEntity objrequest = new gen_eventinfoEntity();
                objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                objrequest.BaseSecurityParam = request.BaseSecurityParam;
                objrequest.CurrentPage = request.s2PageNum.GetValueOrDefault(1);
                objrequest.PageSize = request.s2PageSize.GetValueOrDefault(10);
                objrequest.SortExpression = " eventcategoryid asc ";
                objrequest.strCommonSerachParam = request.s2SearchTerm;
                objrequest.ControllerName = "Gen_EventInfo";
                await _gen_EventInfoUseCase.GetDataForDropDown(new Gen_EventInfoRequest(objrequest), _gen_EventInfoPresenter);
                return Json(_gen_EventInfoPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteGen_EventFileInfo([FromBody] gen_eventfileinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }

            ModelState.Remove("filetype");
            ModelState.Remove("extension");

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", request.filename);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);

            }
            await _gen_EventFileInfoUseCase.Delete(new Gen_EventFileInfoRequest(request), _gen_EventFileInfoPresenter);
            return _gen_EventFileInfoPresenter.ContentResult;
        }



        [HttpGet]
        public async Task<IActionResult> SearchEventInfo(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userid = claimsIdentity.Claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").FirstOrDefault().Value;

            gen_unitEntity objrequest = new gen_unitEntity();
            objrequest.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
            objrequest.BaseSecurityParam.userid = Guid.Parse(userid);
            objrequest.CurrentPage = 1;
            objrequest.PageSize = 10;
            objrequest.SortExpression = " unit asc ";
            objrequest.ControllerName = "Gen_Unit";

            await _gen_UnitUseCase.GetDataForDropDownByUserId(new Gen_UnitRequest(objrequest), _gen_UnitPresenter);
            try
            {
                List<gen_dropdownEntity> Data = (List<gen_dropdownEntity>)(((AjaxResponse)_gen_UnitPresenter.Result).data);
                if (Data.Count == 1)
                {
                    var datagen_unit = (new { Id = Data.FirstOrDefault().Id, Text = Data.FirstOrDefault().Text });
                    ViewBag.preloadedDatagen_unit = JsonConvert.SerializeObject(datagen_unit);
                }
            }
            catch (Exception)
            {

            }



            return View("../General/Gen_EventInfo/SearchEvent", new gen_eventinfoEntity());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchEventInfo(EventSearchEntity request)
        {
            try
            {
                gen_eventinfoEntity genev = new gen_eventinfoEntity();
                genev.eventcategoryid = request.eventcategoryid;
                genev.eventid = request.eventid;
                genev.eventname = request.eventname;
                genev.eventstartdate = request.eventstartdate;
                genev.eventenddate = request.eventenddate;
                genev.unitid = request.unitid;
                genev.eventdescription = request.eventdescription;

                genev.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                genev.BaseSecurityParam = request.BaseSecurityParam;
                genev.CurrentPage = request.Start == 0 ? 1 : request.Start / request.Length + 1;
                genev.PageSize = request.Length;
                genev.SortExpression = request.SortOrder + " " + request.Order[0].Dir;
                genev.strCommonSerachParam = request.Search.Value;
                genev.ControllerName = "Gen_EventInfo";

                await _gen_EventInfoUseCase.SearchEventInfo(new Gen_EventInfoRequest(genev), _gen_EventInfoPresenter);
                return Json(_gen_EventInfoPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetEventFileInfoByEvent([FromBody] gen_eventfileinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            ModelState.Remove("filetype");
            ModelState.Remove("extension");
            ModelState.Remove("filename");
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            
            await _gen_EventFileInfoUseCase.GetAll(new Gen_EventFileInfoRequest(request), _gen_EventFileInfoPresenter);
            List<gen_eventfileinfoEntity> _objEventFiles = new List< gen_eventfileinfoEntity>();
            _objEventFiles = _gen_EventFileInfoPresenter.Result as List<gen_eventfileinfoEntity>;

            gen_eventinfoEntity genev = new gen_eventinfoEntity();
            if (_objEventFiles.Count > 0)
            {
                foreach (var file in _objEventFiles)
                {
                    file.FileUrl = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", file.filename);
                }
            }
            if (_objEventFiles.Count > 0) return Json(new { status = "success", data = _objEventFiles });
            else return Json(new { status = "failed", data = new List<gen_eventfileinfoEntity>() });
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetReport_DigestOfService([FromBody] gen_eventinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            ModelState.Remove("eventid");
            ModelState.Remove("eventcategoryid");
            ModelState.Remove("eventcode");
            ModelState.Remove("eventname");
            ModelState.Remove("eventstartdate");
            ModelState.Remove("eventenddate");
            ModelState.Remove("eventdescription");
            ModelState.Remove("eventdescription1");
            ModelState.Remove("eventdescription2");
            ModelState.Remove("eventspecialnote");
            ModelState.Remove("isdeleted");
            ModelState.Remove("eventorganizedby");
            ModelState.Remove("ex_nvarchar3");
            if (!ModelState.IsValid) { return BadRequest(ModelState); }


            gen_eventinfoEntity genev = new gen_eventinfoEntity();
            genev.eventcategoryid = request.eventcategoryid;
            genev.eventid = request.eventid;
            genev.eventname = request.eventname;
            genev.eventstartdate = request.eventstartdate;
            genev.eventenddate = request.eventenddate;
            genev.unitid = request.unitid;
            genev.eventdescription = request.eventdescription;

            await _gen_EventInfoUseCase.GetAll(new Gen_EventInfoRequest(genev), _gen_EventInfoPresenter);
            List<gen_eventinfoEntity> _objEventList = new List<gen_eventinfoEntity>();
            _objEventList = _gen_EventInfoPresenter.Result as List<gen_eventinfoEntity>;

            gen_eventfileinfoEntity objEventFile = new gen_eventfileinfoEntity();
            objEventFile.eventid = genev.eventid;
            await _gen_EventFileInfoUseCase.GetAll(new Gen_EventFileInfoRequest(objEventFile), _gen_EventFileInfoPresenter);
            List<gen_eventfileinfoEntity> _objEventFiles = new List<gen_eventfileinfoEntity>();
            _objEventFiles = _gen_EventFileInfoPresenter.Result as List<gen_eventfileinfoEntity>;
            this._objEventFilesReport = _gen_EventFileInfoPresenter.Result as List<gen_eventfileinfoEntity>;

            if (_objEventFiles.Count > 0)
            {
                foreach (var file in _objEventFiles)
                {
                    file.FileUrl = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", file.filename);
                }
            }
            var bytearrReport = await GenerateReport(
                                _objEventList,
                                _objEventFiles.ToList()
                                );
            //var reportBase64 = Convert.ToBase64String(bytearrReport);

            //return Json(new { status = "success", data = reportBase64 });
            return File(bytearrReport, "application/pdf", "Report.pdf");
        }


        private async Task<byte[]> GenerateReport(
          List<gen_eventinfoEntity> gen_eventinfoList,
          List<gen_eventfileinfoEntity> gen_eventfileinfoList)
        {
            string fileDirPath = _webhost.WebRootPath;
            string rdlcFilePath = string.Format("{0}\\Reports\\rptDigestOfService.rdlc", fileDirPath);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("UTF-8");

            string FileName = "DigestOfService_" + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
            string extension;
            string encoding;
            string mimeType;
            string[] streams;
            Warning[] warnings;

            var reportparameter = new[] {
                            new ReportParameter("eventid", gen_eventinfoList[0].eventid.ToString())
                        };

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("UTF-8");

            LocalReport report = new LocalReport();
            report.ReportPath = rdlcFilePath;
            report.EnableExternalImages = true;

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = gen_eventinfoList;

            List<gen_eventfileinfoReportEntity> objFiles = new List<gen_eventfileinfoReportEntity>();
            gen_eventfileinfoReportEntity objFile = new gen_eventfileinfoReportEntity();

            report.DataSources.Add(rds);
            report.SetParameters(reportparameter);
            report.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing); ;
            var result = report.Render("pdf", null,
                            out extension, out encoding,
                            out mimeType, out streams, out warnings);
            return result;
        }
        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            // Use FileStream to read the image in a memory-efficient way
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                byte[] imageBytes = new byte[fs.Length]; // Initialize byte array to file length
                fs.Read(imageBytes, 0, (int)fs.Length);  // Read file into byte array
                return imageBytes;
            }
        }
        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (e.ReportPath == "rptEventFilesSubreport")
            {
                List<gen_eventfileinfoReportEntity> objFiles = new List<gen_eventfileinfoReportEntity>();
                var eventid = Convert.ToInt64(e.Parameters["eventid"].Values.FirstOrDefault().ToString());
                var ObjEventFiles = this._objEventFilesReport.Where(p=> p.eventid == eventid).ToList();

                for (int i = 0; i < ObjEventFiles.Count; i++)
                {
                    try
                    {
                        gen_eventfileinfoReportEntity objFile = new gen_eventfileinfoReportEntity();
                        try { objFile.ImageData1 = ConvertImageToByteArray(ObjEventFiles[i + 0].FileUrl); } catch { }
                        try { objFile.ImageData2 = ConvertImageToByteArray(ObjEventFiles[i + 1].FileUrl); } catch { }
                        try { objFile.ImageData3 = ConvertImageToByteArray(ObjEventFiles[i + 2].FileUrl); } catch { }
                        try { objFile.ImageData4 = ConvertImageToByteArray(ObjEventFiles[i + 3].FileUrl); } catch { }
                        i = i + 3;

                        objFiles.Add(objFile);
                    }
                    catch { }
                }
                var _objEventFiles = new ReportDataSource() { Name = "DataSet1", Value = objFiles };
                e.DataSources.Add(_objEventFiles);
            }
        }
        public static string ConvertImageToBase64String(string imagePath)
        {
            string result = null;
            if (!string.IsNullOrEmpty(imagePath))
            {
                using (var b = new Bitmap(imagePath))
                {
                    using (var ms = new MemoryStream())
                    {
                        b.Save(ms, ImageFormat.Bmp);
                        result = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return result;
        }

        private byte[] GetImageBytes(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    return ms.ToArray();
                }
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetReport_UnitDigest([FromBody] gen_eventinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            ModelState.Remove("eventid");
            ModelState.Remove("eventcategoryid");
            ModelState.Remove("eventcode");
            ModelState.Remove("eventname");
            ModelState.Remove("eventstartdate");
            ModelState.Remove("eventenddate");
            ModelState.Remove("eventdescription");
            ModelState.Remove("eventdescription1");
            ModelState.Remove("eventdescription2");
            ModelState.Remove("eventspecialnote");
            ModelState.Remove("isdeleted");
            ModelState.Remove("eventorganizedby");
            ModelState.Remove("ex_nvarchar3");
            if (!ModelState.IsValid) { return BadRequest(ModelState); }


            gen_eventinfoEntity genev = new gen_eventinfoEntity();
            genev.eventcategoryid = request.eventcategoryid;
            genev.eventid = request.eventid;
            genev.eventname = request.eventname;
            genev.eventstartdate = request.eventstartdate;
            genev.eventenddate = request.eventenddate;
            genev.unitid = request.unitid;
            genev.eventdescription = request.eventdescription;

            await _gen_EventInfoUseCase.GetAll(new Gen_EventInfoRequest(genev), _gen_EventInfoPresenter);
            List<gen_eventinfoEntity> _objEventList = new List<gen_eventinfoEntity>();
            _objEventList = _gen_EventInfoPresenter.Result as List<gen_eventinfoEntity>;

            gen_eventfileinfoEntity objEventFile = new gen_eventfileinfoEntity();
            objEventFile.eventid = genev.eventid;
            await _gen_EventFileInfoUseCase.GetAll(new Gen_EventFileInfoRequest(objEventFile), _gen_EventFileInfoPresenter);
            List<gen_eventfileinfoEntity> _objEventFiles = new List<gen_eventfileinfoEntity>();
            _objEventFiles = _gen_EventFileInfoPresenter.Result as List<gen_eventfileinfoEntity>;
            this._objEventFilesReport = _gen_EventFileInfoPresenter.Result as List<gen_eventfileinfoEntity>;

            if (_objEventFiles.Count > 0)
            {
                foreach (var file in _objEventFiles)
                {
                    file.FileUrl = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", file.filename);
                }
            }
            var bytearrReport = await GenerateReport_UnitDigest(
                                _objEventList,
                                _objEventFiles.ToList()
                                );
            //var reportBase64 = Convert.ToBase64String(bytearrReport);

            //return Json(new { status = "success", data = reportBase64 });
            return File(bytearrReport, "application/pdf", "Report.pdf");
        }


        private async Task<byte[]> GenerateReport_UnitDigest(
          List<gen_eventinfoEntity> gen_eventinfoList,
          List<gen_eventfileinfoEntity> gen_eventfileinfoList)
        {
            string fileDirPath = _webhost.WebRootPath;
            string rdlcFilePath = string.Format("{0}\\Reports\\rptUnitDigest.rdlc", fileDirPath);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("UTF-8");

            string FileName = "Digest_" + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
            string extension;
            string encoding;
            string mimeType;
            string[] streams;
            Warning[] warnings;

            DateTime? minDate = gen_eventinfoList.Min(e => e.eventstartdate);
            DateTime? maxDate = gen_eventinfoList.Max(e => e.eventstartdate);

            var reportparameter = new[] {
                            new ReportParameter("eventid", gen_eventinfoList[0].eventid.ToString()),
                            new ReportParameter("HeadingOne", $"UNIT-DIGEST-{gen_eventinfoList[0].unitcode}"),
                            new ReportParameter("HeadingTwo", $"PERIOD COVERING: {Convert.ToDateTime(minDate).ToString("dd-MM-yyyy")} to {Convert.ToDateTime(maxDate).ToString("dd-MM-yyyy")}")
                        };

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("UTF-16");

            LocalReport report = new LocalReport();
            report.ReportPath = rdlcFilePath;
            report.EnableExternalImages = true;

            //gen_eventinfoList.ToList().ForEach(e => e.eventstartdate);

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = gen_eventinfoList;

            List<gen_eventfileinfoReportEntity> objFiles = new List<gen_eventfileinfoReportEntity>();
            gen_eventfileinfoReportEntity objFile = new gen_eventfileinfoReportEntity();

            report.DataSources.Add(rds);
            report.SetParameters(reportparameter);
            report.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing_UnitDigest); ;
            var result = report.Render("pdf", null,
                            out extension, out encoding,
                            out mimeType, out streams, out warnings);
            return result;
        }

        private void LocalReport_SubreportProcessing_UnitDigest(object sender, SubreportProcessingEventArgs e)
        {
            if (e.ReportPath == "rptUnitDigestEventFilesSubreport")
            {
                List<gen_eventfileinfoReportEntity> objFiles = new List<gen_eventfileinfoReportEntity>();
                var eventid = Convert.ToInt64(e.Parameters["eventid"].Values.FirstOrDefault().ToString());
                var ObjEventFiles = this._objEventFilesReport.Where(p => p.eventid == eventid).ToList();

                for (int i = 0; i < ObjEventFiles.Count; i++)
                {
                    try
                    {
                        gen_eventfileinfoReportEntity objFile = new gen_eventfileinfoReportEntity();
                        try
                        {
                            objFile.ImageData1 = ConvertImageToByteArray(ObjEventFiles[i + 0].FileUrl);
                            objFile.image1 = ObjEventFiles[i + 0].FileUrl;
                        }
                        catch { }
                        try
                        {
                            objFile.ImageData2 = ConvertImageToByteArray(ObjEventFiles[i + 1].FileUrl);
                            objFile.image2 = ObjEventFiles[i + 1].FileUrl;
                        }
                        catch { }
                        //try { objFile.ImageData3 = ConvertImageToByteArray(ObjEventFiles[i + 2].FileUrl); } catch { }
                        //try { objFile.ImageData4 = ConvertImageToByteArray(ObjEventFiles[i + 3].FileUrl); } catch { }
                        i = i + 1;

                        objFiles.Add(objFile);
                    }
                    catch { }
                }
                var _objEventFiles = new ReportDataSource() { Name = "DataSet1", Value = objFiles };
                e.DataSources.Add(_objEventFiles);
            }
        }

        static string ConvertEnglishToBanglaNumber(string englishNumber)
        {
            // Array mapping English digits to Bengali digits
            char[] banglaDigits = new char[] { '০', '১', '২', '৩', '৪', '৫', '৬', '৭', '৮', '৯' };

            // Replace each English digit with the corresponding Bengali digit
            char[] result = new char[englishNumber.Length];
            for (int i = 0; i < englishNumber.Length; i++)
            {
                char englishDigit = englishNumber[i];

                // Convert only if the character is a digit (0-9)
                if (char.IsDigit(englishDigit))
                {
                    result[i] = banglaDigits[englishDigit - '0'];
                }
                else
                {
                    // If it's not a digit, keep it unchanged
                    result[i] = englishDigit;
                }
            }

            return new string(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFont(IFormFile file)
        {
            try
            {
                string fontName = "";
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }


                // Path where you want to save the font file
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fonts", file.FileName);

                // Create the directory if it doesn't exist
                var directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Save the file to the specified path
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    fontName = GetFontNameFromTff(path);
                }


                System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fonts", "fontname.txt"), fontName);
                //using (StreamWriter writer = new StreamWriter(path, false)) // 'false' ensures the file is overwritten (cleared)
                //{
                //    writer.WriteLine(fontName);  // Writes the text to the file
                //}

                return Ok(new { FilePath = path, fontname = fontName, status = "success" });
            }
            catch (Exception ex)
            {
                return Ok(new { status = "failed" });
            }
        }

        public static string GetFontNameFromTff(string tffFilePath)
        {
            using (PrivateFontCollection fontCollection = new PrivateFontCollection())
            {
                fontCollection.AddFontFile(tffFilePath);
                if (fontCollection.Families.Length > 0)
                {
                    return fontCollection.Families[0].Name;
                }
                return null; // Return null if no font is found.
            }
        }
    }
}
