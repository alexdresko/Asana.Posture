namespace NsTasks.Web.Ui1
{
	using System.Web;
	using System.Web.Http;
	using System.Web.Mvc;
	using System.Web.Optimization;
	using System.Web.Routing;

	using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		#region Public Methods and Operators

		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AuthorizeAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

			routes.MapRoute("xrds", "xrds", new { controller = "Home", action = "xrds" });

			routes.MapRoute(
				"Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
		}

		#endregion

		#region Methods

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			BundleTable.Bundles.RegisterTemplateBundles();
		}

		#endregion
	}
}