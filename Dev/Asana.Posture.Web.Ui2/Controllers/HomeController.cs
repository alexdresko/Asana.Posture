namespace Asana.Posture.Web.Ui2.Controllers
{
	using System;
	using System.Web.Mvc;

	[AllowAnonymous]
	public partial class HomeController : Controller
	{
		public virtual ActionResult Index()
		{
			this.Response.AppendHeader(
	"X-XRDS-Location",
	new Uri(this.Request.Url, this.Response.ApplyAppPathModifier("~/Home/xrds")).AbsoluteUri);

			if (this.Request.IsAuthenticated)
			{
				return RedirectToAction(MVC.Asana.Index());
			}
			
			return this.View("Index");
		}

		public virtual ActionResult Xrds()
		{
			return this.View("Xrds");
		}
	}
}
