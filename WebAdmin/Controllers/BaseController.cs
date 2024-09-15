using AppConfig.HelperClasses;
using BDO.Core.DataAccessObjects.CommonEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace WebAdmin.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessorBase;

        public BaseController(
            )
        {
            if (Request != null) /* The user object is found to be null here. */
            {
                string referer = Request.Headers["Referer"].ToString();
            }
          
        }

        public clsPrivateKeys objClsPrivate = new clsPrivateKeys();

        /// <summary>
        /// 
        /// </summary>
        //public IStringLocalizer _sharedLocalizer;
        /// <summary>
        /// AddBreadcrumb
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="urlPath"></param>
        internal void AddBreadcrumb(string displayName, string urlPath)
        {
            List<Message> messages;

            if (ViewBag.Breadcrumb == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = ViewBag.Breadcrumb as List<Message>;
            }

            messages.Add(new Message { DisplayName = displayName, URLPath = urlPath });
            ViewBag.Breadcrumb = messages;
        }


        /// <summary>
        /// AddPageHeader
        /// </summary>
        /// <param name="pageHeader"></param>
        /// <param name="pageDescription"></param>
        internal void AddPageHeader(string pageHeader = "", string pageDescription = "")
        {
            ViewBag.PageHeader = Tuple.Create(pageHeader, pageDescription);
        }

        /// <summary>
        /// PageAlertType
        /// </summary>
        internal enum PageAlertType
        {
            Error,
            Info,
            Warning,
            Success
        }

        /// <summary>
        /// AddPageAlerts
        /// </summary>
        /// <param name="pageAlertType"></param>
        /// <param name="description"></param>
        internal void AddPageAlerts(PageAlertType pageAlertType, string description)
        {
            List<Message> messages;

            if (ViewBag.PageAlerts == null)
            {
                messages = new List<Message>();
            }
            else
            {
                messages = ViewBag.PageAlerts as List<Message>;
            }

            messages.Add(new Message { Type = pageAlertType.ToString().ToLower(), ShortDesc = description });
            ViewBag.PageAlerts = messages;
        }

        /// <summary>
        /// options
        /// </summary>
        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };


    }
}
