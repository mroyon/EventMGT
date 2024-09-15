
using CLL.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAdmin.ViewComponents
{
/// <summary>
	/// S2Owin_FormAction ViewComponent
	/// </summary>
	public class S2Owin_FormActionViewComponent : ViewComponent
	{
		private readonly ILogger<S2Owin_FormActionViewComponent> _logger;
		private readonly IStringLocalizer _sharedLocalizer;
		/// <summary>
		/// S2Owin_FormActionViewComponent
		/// </summary>
		public S2Owin_FormActionViewComponent(
			ILoggerFactory loggerFactory,
			IStringLocalizerFactory factory
			)
		{
			_logger = loggerFactory.CreateLogger<S2Owin_FormActionViewComponent>();
			var type = typeof(SharedResource);
			var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
			_sharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
		}

		/// <summary>
		/// IViewComponentResult
		/// </summary>
		/// <param name="selectid"></param>
		/// <param name="preloaded"></param>
		/// <param name="isReadOnly"></param>
		/// <param name="multiple"></param>
		/// <param name="isRequired"></param>
		/// <param name="pkey"></param>
		/// <returns></returns>
		public IViewComponentResult Invoke(
			string selectid,
			string preloaded,
			bool isReadOnly = false,
			bool multiple = false,
			bool isRequired = false,
			int? pkey = null)
		{
			 ViewBag.selectid = selectid;
			ViewBag.Owin_FormActionData = preloaded;
			ViewBag.isReadOnly = isReadOnly;
			ViewBag.multiple = multiple;
			ViewBag.isRequired = isRequired;
			ViewBag.pkey = pkey == null? "": pkey.GetValueOrDefault().ToString();
			return View();
		}

	}
}







