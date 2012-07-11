using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewMvc4ProjectReference.Controllers
{
	using System.Web.Mvc;

	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
