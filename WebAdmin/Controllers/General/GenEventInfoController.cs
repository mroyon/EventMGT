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

namespace WebAdmin.Controllers
{
    /// <summary>
    /// Gen_EventInfoController
    /// </summary>
    [Authorize(Policy = "KAFSecurityPolicy")]
    [AutoValidateAntiforgeryToken]
    public class Gen_EventInfoController : BaseController
    {
        private readonly IGen_EventInfoUseCase _gen_EventInfoUseCase;
        private readonly Gen_EventInfoPresenter _gen_EventInfoPresenter;

        private readonly IGen_EventFileInfoUseCase _gen_EventFileInfoUseCase;
        private readonly Gen_EventFileInfoPresenter _gen_EventFileInfoPresenter;

        private readonly ICacheProvider _cacheProvider;


        private readonly IGen_EventCategoryUseCase _gen_EventCategoryUseCase;
        private readonly Gen_EventCategoryPresenter _gen_EventCategoryPresenter;
        private readonly IGen_UnitUseCase _gen_UnitUseCase;
        private readonly Gen_UnitPresenter _gen_UnitPresenter;



        private readonly ILogger<Gen_EventInfoController> _logger;
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        private readonly IWebHostEnvironment _webHostEnvironment;


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

             , IGen_EventCategoryUseCase gen_EventCategoryUseCase
            , Gen_EventCategoryPresenter gen_EventCategoryPresenter
, IGen_UnitUseCase gen_UnitUseCase
            , Gen_UnitPresenter gen_UnitPresenter
,
IGen_EventFileInfoUseCase gen_EventFileInfoUseCase
,
Gen_EventFileInfoPresenter gen_EventFileInfoPresenter,
IWebHostEnvironment webHostEnvironment)
        {
            _gen_EventInfoUseCase = gen_EventInfoUseCase;
            _gen_EventInfoPresenter = gen_EventInfoPresenter;
            _logger = loggerFactory.CreateLogger<Gen_EventInfoController>();
            _schemeProvider = schemeProvider;


            _gen_EventCategoryUseCase = gen_EventCategoryUseCase;
            _gen_EventCategoryPresenter = gen_EventCategoryPresenter;
            _gen_UnitUseCase = gen_UnitUseCase;
            _gen_UnitPresenter = gen_UnitPresenter;



            //_hubuserContext = hubuserContext;
            //_userConnectionManager = userConnectionManager;
            _cacheProvider = cacheProvider;

            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
            _gen_EventFileInfoUseCase = gen_EventFileInfoUseCase;
            _gen_EventFileInfoPresenter = gen_EventFileInfoPresenter;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> AddGen_EventInfo([FromForm] gen_eventinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            // Process each file
            var objGen_EventFileInfo = new List<gen_eventfileinfoEntity>();
            request.EventfileinfoList = new List<gen_eventfileinfoEntity>();
            var files = Request.Form.Files;
            foreach (var item in request.postedFiles)
            {
                var file = item.file;

                var UniqueFileName = Guid.NewGuid().ToString();

                // Save the file (example)
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);
                var fileExtension = Path.GetExtension(filePath);

                using (var stream = new FileStream($"{UniqueFileName}{fileExtension}", FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                gen_eventfileinfoEntity objFile = new gen_eventfileinfoEntity();
                objFile.filename = $"{UniqueFileName}{fileExtension}";
                objFile.filetitle = file.FileName;
                string contentType = string.Empty;
                new FileExtensionContentTypeProvider().TryGetContentType(file.FileName, out contentType);
                objFile.filetype = contentType;
                objFile.extension = fileExtension;
                objFile.filesize = file.Length;
                objFile.BaseSecurityParam = request.BaseSecurityParam;
                objGen_EventFileInfo.Add(objFile);
            }
            request.EventfileinfoList = objGen_EventFileInfo;
            await _gen_EventInfoUseCase.Save(new Gen_EventInfoRequest(request), _gen_EventInfoPresenter);
            return _gen_EventInfoPresenter.ContentResult;
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
        public async Task<IActionResult> EditGen_EventInfo([FromForm] gen_eventinfoEntity request)
        {
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Account", "Login"); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var objGen_EventFileInfo = new List<gen_eventfileinfoEntity>();
            request.EventfileinfoList = new List<gen_eventfileinfoEntity>();
            
            foreach (var item in request.postedFiles) { 
                
                var file = item.file ;
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
                objFile.filedescription=  item.fileDescription;
                objFile.BaseSecurityParam = request.BaseSecurityParam;
                objGen_EventFileInfo.Add(objFile);
            }
            request.EventfileinfoList = objGen_EventFileInfo;


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
            return View("../General/Gen_EventInfo/SearchEvent", new gen_eventinfoEntity());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchEventInfo(EventSearchEntity objrequest)
        {
            try
            {
                gen_eventinfoEntity genev = new gen_eventinfoEntity();
                genev.eventcategoryid = objrequest.eventcategoryid;
                genev.eventid = objrequest.eventid;
                genev.eventname = objrequest.eventname;
                genev.eventstartdate = objrequest.eventstartdate;
                genev.eventenddate = objrequest.eventenddate;

                await _gen_EventInfoUseCase.SearchEventInfo(new Gen_EventInfoRequest(genev), _gen_EventInfoPresenter);
                return Json(_gen_EventInfoPresenter.Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}