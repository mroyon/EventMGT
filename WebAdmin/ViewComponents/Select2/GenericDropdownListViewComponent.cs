
using AutoMapper.Configuration;
using BDO.Core.DataAccessObjects.CommonEntities;
using BDO.Core.DataAccessObjects.HRDomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Core.Frame.Interfaces.Services;

namespace WebAdmin.ViewComponents.Select2
{
    /// <summary>
    /// SideBarMenu
    /// </summary>
    public class GenericDropdownListViewComponent : ViewComponent
    {
        //private IPostRepository repository;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IStringCompression _stringCompression;
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly hrwebapiconnectionsettings _hrwebapiconnectionsettings;
        /// <summary>
        /// AboutUsViewComponent
        /// </summary>
        public GenericDropdownListViewComponent(IHttpContextAccessor contextAccessor,
            IStringCompression stringCompression,
           IConfiguration config)
        {
            _config = config;
            _contextAccessor = contextAccessor;
            _stringCompression = stringCompression;


        }


        public IViewComponentResult Invoke(string ddlId, string strobjlist, string selectedvalue, string cssclass = "", bool enable = true, bool isRequired = false)
        {
            var objlist = JsonConvert.DeserializeObject<List<SelectListItem>>(strobjlist);

            List<SelectListItem> dlList = new List<SelectListItem>();
            //dlList.Add(new SelectListItem { Text = "- اختر واحدة -", Value = "" });
            foreach (var p in objlist)
            {
                dlList.Add(p);
            }

            ViewBag.ddlTitle = "";
            ViewBag.ddlName = dlList;
            ViewBag.ddlId = ddlId;
            ViewBag.ddlcss = cssclass;
            ViewBag.enable = enable;
            ViewBag.selectedvalue = selectedvalue;
            ViewBag.isRequired = isRequired;

            return View("~/Views/Shared/Components/Select2/GenericDropDownList.cshtml");
        }

    }
}
