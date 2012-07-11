namespace Asana.Posture.Web.Ui2.App_Start
{
	using System.Web.Optimization;

	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/libs/jquery-1.*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
			"~/Scripts/libs/bootstrap/bootstrap.min.js"));
			
			var kendoJsBundle = new ScriptBundle("~/bundles/kendoui").Include("~/Scripts/libs/kendoui/kendo.web.min.js");
			bundles.Add(kendoJsBundle);


			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
						"~/Scripts/libs/jquery-ui*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/libs/jquery.unobtrusive*",
						"~/Scripts/libs/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/libs/modernizr-*"));

			bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/kenny").Include("~/Content/kendoui/kendo.common.min.css", "~/Content/kendoui/posture.css"));

			bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
						"~/Content/themes/base/jquery.ui.core.css",
						"~/Content/themes/base/jquery.ui.resizable.css",
						"~/Content/themes/base/jquery.ui.selectable.css",
						"~/Content/themes/base/jquery.ui.accordion.css",
						"~/Content/themes/base/jquery.ui.autocomplete.css",
						"~/Content/themes/base/jquery.ui.button.css",
						"~/Content/themes/base/jquery.ui.dialog.css",
						"~/Content/themes/base/jquery.ui.slider.css",
						"~/Content/themes/base/jquery.ui.tabs.css",
						"~/Content/themes/base/jquery.ui.datepicker.css",
						"~/Content/themes/base/jquery.ui.progressbar.css",
						"~/Content/themes/base/jquery.ui.theme.css"));
		}
	}
}