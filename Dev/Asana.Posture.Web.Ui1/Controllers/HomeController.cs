namespace NsTasks.Web.Ui1.Controllers
{
	using System;
	using System.Web.Mvc;

	[AllowAnonymous]
	public partial class HomeController : Controller
	{
		public virtual ActionResult Index()
		{
			Response.AppendHeader(
	"X-XRDS-Location",
	new Uri(Request.Url, Response.ApplyAppPathModifier("~/Home/xrds")).AbsoluteUri);

			if (Request.IsAuthenticated)
			{
				return RedirectToAction(MVC.Asana.Index());
			}
			
			return this.View("Index");
		}

		public virtual ActionResult Xrds()
		{
			return View("Xrds");
		}
	}
}
