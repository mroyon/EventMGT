using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Web.Core.Frame.CustomIdentityManagers;
using CLL.Localization;
using BDO.Core.DataAccessObjects.ExtendedEntities;


namespace WebAdmin.ViewComponents
{
    /// <summary>
    /// HeaderViewComponent
    /// </summary>
    public class FileUploaderViewComponent : ViewComponent
    {
        private readonly ILogger<FileUploaderViewComponent> _logger;
       
        /// <summary>
        /// AboutUsViewComponent
        /// </summary>
        public FileUploaderViewComponent(
            ILoggerFactory loggerFactory
            )
        {
            _logger = loggerFactory.CreateLogger<FileUploaderViewComponent>();
           
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="submitbutton"></param>
        /// <returns></returns>
        public IViewComponentResult Invoke(
            string foldername, string submitbutton)
        {
            ViewBag.foldername = foldername;
            ViewBag.submitbutton = submitbutton;

            return View("~/Views/Shared/Components/FileUploader/FileUploader.cshtml");
        }

    }
}
